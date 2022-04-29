using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using P3L5YQ_HFT_2021221.Endpoint.Services;
using P3L5YQ_HFT_2021221.Logic;
using P3L5YQ_HFT_2021221.Models;

namespace P3L5YQ_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TrimLevelController : ControllerBase
    {
        public ITrimLevelLogic trimLevelLogic;
        IHubContext<SignalRHub> hub;

        public TrimLevelController(ITrimLevelLogic TrimLevelLogic, IHubContext<SignalRHub> hub)
        {
            this.trimLevelLogic = TrimLevelLogic;
            this.hub = hub;
        }
        // GET: /TrimLevel
        [HttpGet("{id}")]
        public JsonResult HttpGetOne(int id)
        {
            return new JsonResult(trimLevelLogic.Read(id));
        }
        // GET TrimLevel/5
        [HttpGet]
        public JsonResult HttpGetAll()
        {
            return new JsonResult(trimLevelLogic.ReadAll());
        }
        // POST /TrimLevel
        [HttpPost]
        public JsonResult HttpPost(TrimLevel trimLevel)
        {
            this.hub.Clients.All.SendAsync("TrimLevelCreated", trimLevel);
            return new JsonResult(trimLevelLogic.Create(trimLevel));
        }
        // DELETE /TrimLevel/5
        [HttpDelete("{id}")]
        public JsonResult HttpDelete(int id)
        {
            var trimDeleted = trimLevelLogic.Read(id);
            this.hub.Clients.All.SendAsync("TrimLevelDeleted", trimDeleted);
            return new JsonResult(trimLevelLogic.Delete(id));
        }
        // PUT /TrimLevel
        [HttpPut("{id}")]
        public JsonResult HttpUpdate([FromBody]TrimLevel trimLevel, int id)
        {
            this.hub.Clients.All.SendAsync("TrimLevelUpdated", trimLevel);
            return new JsonResult(trimLevelLogic.Update(trimLevel, id));
        }
    }
}
