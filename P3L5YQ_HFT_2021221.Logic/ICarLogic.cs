namespace P3L5YQ_HFT_2021221.Logic
{
    using P3L5YQ_HFT_2021221.Models.HelperClasses;
    using P3L5YQ_HFT_2021221.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface ICarLogic : IGeneralLogic
    {
        public bool Create(Car car);
        public bool Delete(int id);
        public Car Read(int id);
        public bool Update(Car car, int id);
        public IEnumerable<Car> ReadAll();

        public List<OdometerByEngineType> GetAvgOdometerStateByEngineType();
        public List<ChassisTypeAVGPrice> GetAvgPriceByCarChasisType();
        public List<AverageMileageByFuelType> GetAverageMileageByFuelType();
        public List<SoldCarsbyFuelType> SoldCarsByFuelType();
        public List<AVGManufDateByFuelType> GetAVGManufDateByFuelType();
    }
}
