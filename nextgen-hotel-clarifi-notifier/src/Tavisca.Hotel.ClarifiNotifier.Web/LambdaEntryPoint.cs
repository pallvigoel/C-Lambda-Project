using System;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Tavisca.Hotel.ClarifiNotifier.Web
{
    /// <summary>
    /// This class extends from APIGatewayProxyFunction which contains the method FunctionHandlerAsync which is the 
    /// actual Lambda function entry point. The Lambda handler field should be set to
    /// 
    /// NonStandardizedRoomHandler::NonStandardizedRoomHandler.LambdaEntryPoint::FunctionHandlerAsync
    /// </summary>
    public class LambdaEntryPoint :
        // When using an ELB's Application Load Balancer as the event source change 
        // the base class to Amazon.Lambda.AspNetCoreServer.ApplicationLoadBalancerFunction
        Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction
    {
        /// <summary>
        /// The builder has configuration, logging and Amazon API Gateway already configured. The startup class
        /// needs to be configured in this method using the UseStartup<>() method.
        /// </summary>
        /// <param name="builder"></param>
        protected override void Init(IWebHostBuilder builder)
        {
            try
            {
                builder
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseStartup<Startup>()
                    .UseLambdaServer();
            }
            catch(Exception ex)
            {
                Amazon.Lambda.Core.LambdaLogger.Log("Exception throw in LambdaEntryPoint: " + ex);

            }
        }
    }
}
