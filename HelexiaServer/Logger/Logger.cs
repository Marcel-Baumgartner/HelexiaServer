using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelexiaServer.Logger
{
    public class Logger
    {
        public enum LogLevel
        {
            Information,
            Warning,
            Error,
            Server,
            Network,
            Other,
            Script,
            ThreadManager
        }

        public static void Log(string message, LogLevel logLevel)
        {
            if(Constants.SystemConstants.colorConsole)
            {
                switch(logLevel)
                {
                    case LogLevel.Information:
                        LogColor("[INFORMATION] " + message, ConsoleColor.Cyan);
                        break;
                    case LogLevel.Warning:
                        LogColor("[WARNING] " + message, ConsoleColor.Yellow);
                        break;
                    case LogLevel.Error:
                        LogColor("[ERROR] " + message, ConsoleColor.Red);
                        break;
                    case LogLevel.Server:
                        LogColor("[SERVER] " + message, ConsoleColor.Gray);
                        break;
                    case LogLevel.Network:
                        LogColor("[NETWORK] " + message, ConsoleColor.Green);
                        break;
                    case LogLevel.Other:
                        LogColor("[OTHER] " + message, ConsoleColor.Magenta);
                        break;
                    case LogLevel.Script:
                        LogColor("[SCRIPT] " + message, ConsoleColor.DarkCyan);
                        break;
                    case LogLevel.ThreadManager:
                        LogColor("[THREADMANAGER] " + message, ConsoleColor.DarkGreen);
                        break;
                }
            }
            else
            {
                switch (logLevel)
                {
                    case LogLevel.Information:
                        LogColorLess("[INFORMATION] " + message);
                        break;
                    case LogLevel.Warning:
                        LogColorLess("[WARNING] " + message);
                        break;
                    case LogLevel.Error:
                        LogColorLess("[ERROR] " + message);
                        break;
                    case LogLevel.Server:
                        LogColorLess("[SERVER] " + message);
                        break;
                    case LogLevel.Network:
                        LogColorLess("[NETWORK] " + message);
                        break;
                    case LogLevel.Other:
                        LogColorLess("[OTHER] " + message);
                        break;
                    case LogLevel.Script:
                        LogColorLess("[SCRIPT] " + message);
                        break;
                    case LogLevel.ThreadManager:
                        LogColorLess("[THREADMANAGER] " + message);
                        break;
                }
            }
        }
        private static void LogColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static void LogColorLess(string message)
        {
            Console.WriteLine(message);
        }
    }
}
