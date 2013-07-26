/*                       ____               ____________
 *                      |    |             |            |
 *                      |    |             |    ________|
 *                      |    |             |   |
 *                      |    |             |   |    
 *                      |    |             |   |    ____
 *                      |    |             |   |   |    |
 *                      |    |_______      |   |___|    |
 *                      |            |  _  |            |
 *                      |____________| |_| |____________|
 *                        
 *      Author(s):      limpygnome (Marcus Craske)              limpygnome@gmail.com
 * 
 *      License:        Creative Commons Attribution-ShareAlike 3.0 Unported
 *                      http://creativecommons.org/licenses/by-sa/3.0/
 * 
 *      Path:           /UberLib.UW/ImageLib.cs
 * 
 *      Change-Log:
 *                      2013-06-26      Created initial class.
 * 
 * *********************************************************************************************************************
 * An image library for reading streamed image data.
 * *********************************************************************************************************************
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Drawing;

namespace UberLib.UW
{
    /// <summary>
    /// An image library for reading streamed image data.
    /// </summary>
    public static class ImageLib
    {
        // Enums *******************************************************************************************************
        public enum FetchResult
        {
            Timeout,
            ErrorHeaders,
            ErrorImageData,
            Success
        }
        // Methods - Static ********************************************************************************************
        /// <summary>
        /// Fetches an image from a HTTP stream and terminates the connection. Arguably could be made more efficient by
        /// leaving the stream open, however this may max-out the available sockets at the destination URL (causing an
        /// unintended DDOS with many users).
        /// </summary>
        /// <param name="url">Destination of content.</param>
        /// <param name="image">The output for the image data.</param>
        /// <returns>The result of the operation.</returns>
        public static FetchResult fetchImage(string url, ref Image image, ref byte[] rawBuffer, ref long totalBytes, bool verifyJpg, int timeout)
        {
            const string contentLengthStr = "Content-Length: "; // The HTTP content-length header line.
            const int maxHeaders = 25;                          // Maximum HTTP headers to parse before giving-up.
            // -- Setup the request and begin reading the response stream
            WebRequest wr = WebRequest.Create(url);
            wr.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
            wr.Timeout = timeout;
            WebResponse resp;
            Stream s;
            try
            {
                resp = wr.GetResponse();
                s = resp.GetResponseStream();
            }
            catch(Exception ex)
            {
                Uber_Watcher.FormDebug.write("fetchImage ~ initiate connection; url: '" + url + "', exception: '" + ex.Message + "'");
                return FetchResult.Timeout;
            }
            // -- Read HTTP headers
            int contentLength = -1;
            try
            {
                int headers = 0;
                string t;
                while (headers++ < maxHeaders && (t = readLine(s, ref totalBytes)).Length > 0)
                {
                    if (t.StartsWith(contentLengthStr) && t.Length > contentLengthStr.Length)
                        int.TryParse(t.Substring(contentLengthStr.Length), out contentLength);
                }
            }
            catch(Exception ex)
            {
                s.Close();
                resp.Close();
                Uber_Watcher.FormDebug.write("fetchImage ~ reading header data; url: '" + url + "', exception: '" + ex.Message + "'!");
                return FetchResult.ErrorHeaders;
            }
            if (contentLength == -1)
                return FetchResult.ErrorHeaders;
            // -- Read image data
            try
            {
                byte[] data = readData(s, contentLength, verifyJpg, ref totalBytes);
                if (data == null)
                    throw new Exception("Failed to read image data; null returned by readData call!");
                MemoryStream ms = new MemoryStream();
                ms.Write(data, 0, data.Length);
                Image i = Image.FromStream(ms);
                ms.Close();
                ms.Dispose();
                if (image != null)
                    image.Dispose();
                image = i;
                rawBuffer = data;
            }
            catch (Exception ex)
            {
                s.Close();
                resp.Close();
                Uber_Watcher.FormDebug.write("fetchImage ~ image parsing; url: '" + url + "', exception: '" + ex.Message + "'!");
                return FetchResult.ErrorImageData;
            }
            s.Close();
            resp.Close();
            return FetchResult.Success;
        }
        /// <summary>
        /// Reads a specified amount of data from a stream.
        /// </summary>
        /// <param name="s">The source stream with data.</param>
        /// <param name="length">Length of the content.</param>
        /// <param name="verifyJpg">Verify the data has correct jpeg SOF and EOF markers.</param>
        /// <returns>Byte array with data or null.</returns>
        public static byte[] readData(Stream s, int length, bool verifyJpg, ref long totalBytes)
        {
            // -- Verify content length
            if (verifyJpg && length < 4)
                return null;
            // -- Create buffer and counter
            byte[] buffer = new byte[length];
            int bytesRead = 0;
            // -- Read the content to the lngth; we may not be able to read all the data at once (thus read them in chunks)
            int bytes;
            while (bytesRead < length)
            {
                bytes = s.Read(buffer, bytesRead, length - bytesRead);
                bytesRead += bytes;
                totalBytes += (long)bytes;
            }
            // -- Verify header data is correct
            if (bytesRead < length || (verifyJpg && (buffer[0] != 0xFF || buffer[1] != 0xD8 || buffer[length - 2] != 0xFF || buffer[length - 1] != 0xD9)))
                return null;
            else
                return buffer;
        }
        /// <summary>
        /// Reads a \r\n line from a stream, intended for reading HTTP header data.
        /// </summary>
        /// <param name="s">The source stream with data.</param>
        /// <returns>The next line read from the stream; excludes \r\n tailing characters.</returns>
        public static string readLine(Stream s, ref long totalBytes)
        {
            const int bufferSize = 512; // The size of the buffer for reading the line.
            // -- Setup the buffer and counter; read until the maximum buffer size or EOL
            byte[] buffer = new byte[bufferSize];
            int bytesRead = 0;
            byte last = 0x0;
            byte t;
            while (s.CanRead && bytesRead < buffer.Length)
            {
                t = (byte)s.ReadByte();
                totalBytes++;
                if (last == '\r' && t == '\n')
                {
                    bytesRead--;
                    break;
                }
                else
                {
                    buffer[bytesRead++] = t;
                    last = t;
                }
            }
            return System.Text.ASCIIEncoding.UTF8.GetString(buffer, 0, bytesRead);
        }
    }
}
