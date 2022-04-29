namespace P3L5YQ_HFT_2021221.Logic
{
    using P3L5YQ_HFT_2021221.Models.HelperClasses;
    using P3L5YQ_HFT_2021221.Models;
    using P3L5YQ_HFT_2021221.Repository;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class CarLogic : ICarLogic
    {
        protected ICarRepository carRepository;

        public CarLogic(ICarRepository carRepo)
        {
            this.carRepository = carRepo;
        }
        public bool Create(Car car)
        {
                if (car.Type == "" || car.TrimPackageId == null)
                {
                Console.WriteLine("asd");
                    throw new MissingFieldException("Component is missing!");
                }
                else
                {                   
                    carRepository.Create(car);
                return true;
                }
        }

        public bool Delete(int id)
        {
            try
            {
                carRepository.Delete(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            } 
        }

        public Car Read(int id)
        {
            return carRepository.Read(id);
        }

        public bool Update(Car car, int id)
        {
            try
            {
                carRepository.Update(car, id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public IEnumerable<Car> ReadAll()
        {
            return carRepository.GetAll();
        }

        public List<OdometerByEngineType> GetAvgOdometerStateByEngineType() //helper: OdometerByEngineType.cs
        {
            var avgOdometerState = from car in carRepository.GetAll()
                                   group car by car.Engine.Enginename into g
                                   select new OdometerByEngineType
                                   {
                                       engineType = g.Key,
                                       avgOdometerState = g.Average(x => x.Mileage)
                                   };
            return avgOdometerState.ToList();
        }
        public List<ChassisTypeAVGPrice> GetAvgPriceByCarChasisType() //helper: ChassisTypeAVGPrice
        {
            var asd = carRepository.GetAll().ToList();


            var avgPricebyChasis = from car in carRepository.GetAll()
                     group car by car.Equipment.Chasis into g
                     select new ChassisTypeAVGPrice
                     {
                         chasisType = g.Key,
                         avgPrice = g.Average(x => x.Price)
                     };
            var result = avgPricebyChasis.ToList();
            return result;
        }
        public List<AverageMileageByFuelType> GetAverageMileageByFuelType() //helper: ChassisTypeAVGPrice
        {
            var avgMileageByFuelType = from car in carRepository.GetAll()
                                       group car by car.Engine.Fuelage into g
                                       select new AverageMileageByFuelType
                                       {
                                           fuelType = g.Key,
                                           avgMileage = Convert.ToInt32(g.Average(x => x.Mileage))
                                       };
            return avgMileageByFuelType.ToList();
        }
        public List<SoldCarsbyFuelType> SoldCarsByFuelType() 
        {
            var numberodcarysByFuelType = from car in carRepository.GetAll()
                                       group car by car.Engine.Fuelage into g
                                       select new SoldCarsbyFuelType
                                       {
                                           fuelType = g.Key,
                                           numberofSoldCars = g.Count()
                                       };
            return numberodcarysByFuelType.ToList();
        }
        public List<AVGManufDateByFuelType> GetAVGManufDateByFuelType() //GetAVGManufDateByFuelType
        {
            var avgManufDateByFuelType = from car in carRepository.GetAll()
                                          group car by car.Engine.Fuelage into g
                                          select new AVGManufDateByFuelType
                                          {
                                              fuelType = g.Key,
                                              avgManufDate = g.Average(car => car.ManufDate)
                                          };
            return avgManufDateByFuelType.ToList();
        }
    }
}

 