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
    public class EngineRepository : Repository<Engine>, IEngineRepository
    {
        public EngineRepository(DealershipDbContext context) : base(context)
        {
        }
        public void Update(Engine engine, int id)
        {
            Engine oldEngine = GetOne(id);
            oldEngine.Displacement = engine.Displacement;
            oldEngine.Enginename = engine.Enginename;
            oldEngine.EngineType = engine.EngineType;
            oldEngine.EruroRating = engine.EruroRating;
            oldEngine.Fuelage = engine.Fuelage;
            oldEngine.PowerOutput = engine.PowerOutput;
            oldEngine.Torque = engine.Torque;
            context.SaveChanges();
        }
    }
}
