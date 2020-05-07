using System;

namespace Tavisca.Hotel.ClarifiNotifier.Web
{
 
       public static class ConsoleLogger
        {
            private static readonly bool _isDebugOn;

            static ConsoleLogger()
            {
                _isDebugOn = EnvironmentVariables.GetIsDebuggingOn();
            }
            public static void WriteInfo(string message) { if (_isDebugOn) Console.WriteLine($"[INFO]: {message}"); }

            public static void WriteException(Exception exn)
            {
                Console.WriteLine($"[EXCEPTION]: {exn.Source} : {exn.Message} {exn.StackTrace}");
                if (exn.InnerException != null)
                {
                    Console.WriteLine($"[EXCEPTION]: {exn.InnerException.Source}  : {exn.InnerException.Message} {exn.InnerException.StackTrace}");
                }
            }
        }
    }

