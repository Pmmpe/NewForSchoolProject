namespace P3L5YQ_HFT_2021221.Repository
{
    using Microsoft.EntityFrameworkCore;
    using P3L5YQ_HFT_2021221.Data;
    using P3L5YQ_HFT_2021221.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(DealershipDbContext context) : base(context)
        {
        }
        public override void Update(Car car, int id)
        {
            Car oldCar = GetOne(id);
            oldCar.ChasisColor = car.ChasisColor;
            oldCar.Condition = car.Condition;
            oldCar.ManufDate = car.ManufDate;
            oldCar.Mileage = car.Mileage;
            oldCar.Price = car.Price;
            oldCar.Type = car.Type;
            context.SaveChanges();
        }
    }
}
