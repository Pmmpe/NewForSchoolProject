using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using P3L5YQ_HFT_2021221.Endpoint.Services;
using P3L5YQ_HFT_2021221.Logic;
using P3L5YQ_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P3L5YQ_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EngineController : ControllerBase
    {
        public IEngineLogic engineLogic;
        IHubContext<SignalRHub> hub;
        public EngineController(IEngineLogic EngineLogic, IHubContext<SignalRHub> hub)
        {
            this.engineLogic = EngineLogic;
            this.hub = hub;
        }
        // GET: /engine
        [HttpGet("{id}")]
        public JsonResult HttpGetOne(int id)
        {
            return new JsonResult(engineLogic.Read(id));
        }
        // GET engine/5
        [HttpGet]
        public JsonResult HttpGetAll()
        {
            return new JsonResult(engineLogic.ReadAll());
        }
        // POST /engine
        [HttpPost]
        public JsonResult HttpPost(Engine engine)
        {
            this.hub.Clients.All.SendAsync("EngineCreated", engine);
            return new JsonResult(engineLogic.Create(engine));          
        }
        // DELETE /engine/5
        [HttpDelete("{id}")]
        public JsonResult HttpDelete(int id)
        {
            var engineDeleted = this.engineLogic.Read(id);
            this.hub.Clients.All.SendAsync("EngineDeleted", engineDeleted);
            return new JsonResult(engineLogic.Delete(id));
        }
        // PUT /engine
        [HttpPut("{id}")]
        public JsonResult HttpUpdate([FromBody] Engine engine, int id)
        {
            this.hub.Clients.All.SendAsync("EngineUpdated", engine);
            return new JsonResult(engineLogic.Update(engine, id));
        }
    }
}
