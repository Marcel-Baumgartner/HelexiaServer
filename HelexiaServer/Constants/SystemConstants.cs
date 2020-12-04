using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConfigReaderC = HelexiaServer.ConfigReader.ConfigReader;

namespace HelexiaServer.Constants
{
    public class SystemConstants
    {
        #region Static Constants
        public static bool isLinux = true;
        public static bool colorConsole = false;
        #endregion
        public static ConfigReaderC configReader = new ConfigReaderC();
        public static void Init()
        {
            configReader.path = "helexia.conf";
            configReader.Read();

            isLinux = Convert.ToBoolean(configReader.GetValue("isLinux"));
            colorConsole = Convert.ToBoolean(configReader.GetValue("colorConsole"));
        }
    }
}
