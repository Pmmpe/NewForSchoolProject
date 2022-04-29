using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P3L5YQ_HFT_2021221.Logic;
using P3L5YQ_HFT_2021221.Models;
using P3L5YQ_HFT_2021221.Models.HelperClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace P3L5YQ_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        public ICarLogic carLogic;
        public StatController(ICarLogic carlogic)
        {
            this.carLogic = carlogic;
        }
        [HttpGet]
        public List<OdometerByEngineType> GetAvgOdometerStateByEngineType()
        {
            return carLogic.GetAvgOdometerStateByEngineType();
        }
        [HttpGet]
        public List<ChassisTypeAVGPrice> GetAvgPriceByCarChasisType()
        {
            return carLogic.GetAvgPriceByCarChasisType();
        }
        [HttpGet]
        public List<AverageMileageByFuelType> GetAverageMileageByFuelType()
        {
            return carLogic.GetAverageMileageByFuelType();
        }
        [HttpGet]
        public List<SoldCarsbyFuelType> SoldCarsByFuelType()
        {
            return carLogic.SoldCarsByFuelType();
        }
        [HttpGet]
        public List<AVGManufDateByFuelType> GetAVGManufDateByFuelType()
        {
            return carLogic.GetAVGManufDateByFuelType();
        }

    }
}
