using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tavisca.Hotel.ClarifiService.Adapter;

namespace Tavisca.Hotel.ClarifiNotifier.Web
{
    [Route("hotel/v1.0/")]
    public class ClarifiNotifierController : Controller
    {
        private IServiceAdapter<RoomStandardizationEvent> Adapter { get; set; }

        public ClarifiNotifierController(IServiceAdapter<RoomStandardizationEvent> adapter)
        {
            Adapter = adapter;
        }
        [Route("clarifi/notifier")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RoomStandardizationEvent request)
        {         
            var result = await Adapter.Notify(request);

            if (result.IsSuccess)
            {
                ConsoleLogger.WriteInfo("Successfully Notified Clarifi Room Mapping Service");
                return Ok(result);

            }

            ConsoleLogger.WriteInfo("An error occured while notifying  Clarifi Room Mapping Service");
                
            
            return BadRequest();

        }

    }
}
