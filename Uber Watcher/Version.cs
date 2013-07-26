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
 *      Path:           /Version.cs
 * 
 *      Change-Log:
 *                      2013-06-26      Created initial class.
 * 
 * *********************************************************************************************************************
 * Version information.
 * *********************************************************************************************************************
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace Uber_Watcher
{
    /// <summary>
    /// Version information.
    /// </summary>
    public static class Version
    {
        /// <summary>
        /// Application's version major.
        /// </summary>
        public static int Major
        {
            get
            {
                return 1;
            }
        }
        /// <summary>
        /// Application's version minor.
        /// </summary>
        public static int Minor
        {
            get
            {
                return 0;
            }
        }
        /// <summary>
        /// Application's version build.
        /// </summary>
        public static int Build
        {
            get
            {
                return 0;
            }
        }
    }
}
