using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tavisca.Hotel.ClarifiNotifier.Web
{
    public static class EnvironmentVariables
    {
        public static string GetClarifiServiceEndpoint()
        {
            var url = Environment.GetEnvironmentVariable("RoomMappingSvcEndpoint");

            if (string.IsNullOrEmpty(url))
            {
                const string message = "The EnvironmentVariable 'RoomMappingSvcEndpoint' is missing.";
                var exn = new Exception(message);
                ConsoleLogger.WriteException(exn);
                throw exn;
            }
            return url;
        }
      
        public static bool GetIsDebuggingOn()
        {
            var debug = Environment.GetEnvironmentVariable("Debug");
            if (string.IsNullOrEmpty(debug))
            {
                return false;
            }
            return debug.ToLower() == "true";
        }
    }
}