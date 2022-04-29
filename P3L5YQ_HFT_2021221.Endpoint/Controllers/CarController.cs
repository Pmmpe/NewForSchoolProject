using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using P3L5YQ_HFT_2021221.Endpoint.Services;
using P3L5YQ_HFT_2021221.Logic;
using P3L5YQ_HFT_2021221.Models;
using P3L5YQ_HFT_2021221.Models.HelperClasses;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace P3L5YQ_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ICarLogic carLogic;
        IHubContext<SignalRHub> hub;
        public CarController(ICarLogic carlogic, IHubContext<SignalRHub> hub)
        {
            this.carLogic = carlogic;
            this.hub = hub;
        }
        // GET: /car 
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return carLogic.ReadAll();
        }

        // GET car/5
        [HttpGet("{id}")]
        public Car Get(int id)
        {
            return carLogic.Read(id);
        }

        // POST /car
        [HttpPost]
        public void Post([FromBody] Car carvalue)
        {
            carLogic.Create(carvalue);
            this.hub.Clients.All.SendAsync("CarCreated", carvalue);
        }

        // PUT /car
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Car carvalue)
        {
            carLogic.Update(carvalue, id);
            this.hub.Clients.All.SendAsync("CarUpdated", carvalue);
        }

        // DELETE /car/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var carDeleted = this.carLogic.Read(id);
            carLogic.Delete(id);
            this.hub.Clients.All.SendAsync("CarDeleted",carDeleted);
        }
        [Route("/avgOdometer")]
        [HttpGet]
        public List<OdometerByEngineType> GetAvgOdometerStateByEngineType()
        {
            return carLogic.GetAvgOdometerStateByEngineType();
        }
        [Route("/avgChasis")]
        [HttpGet]
        public List<ChassisTypeAVGPrice> GetAvgPriceByCarChasisType()
        {
            return carLogic.GetAvgPriceByCarChasisType();
        }
        [Route("/avgMileage")]
        [HttpGet]
        public List<AverageMileageByFuelType> GetAverageMileageByFuelType()
        {
            return carLogic.GetAverageMileageByFuelType();
        }
        [Route("/carsNumber")]
        [HttpGet]
        public List<SoldCarsbyFuelType> SoldCarsByFuelType()
        {
            return carLogic.SoldCarsByFuelType();
        }
        [Route("/avgAVGmanufdate")]
        [HttpGet]
        public List<AVGManufDateByFuelType> GetAVGManufDateByFuelType()
        {
            return carLogic.GetAVGManufDateByFuelType();
        }


    }
}
