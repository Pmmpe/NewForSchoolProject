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
    public class TrimLevelRepository : Repository<TrimLevel>, ITrimLevelRepository
    {
        public TrimLevelRepository(DealershipDbContext context) : base(context)
        {
        }
        public void Update(TrimLevel trimlevel, int id)
        {
            TrimLevel oldTrimlevel = GetOne(id);
            oldTrimlevel.AC = trimlevel.AC;
            oldTrimlevel.AlcantaraInterrior = trimlevel.AlcantaraInterrior;
            oldTrimlevel.AlloWheels = trimlevel.AlloWheels;
            oldTrimlevel.Chasis = trimlevel.Chasis;
            oldTrimlevel.NumberofDoors = trimlevel.NumberofDoors;
            oldTrimlevel.RoofRack = trimlevel.RoofRack;
            oldTrimlevel.TrimPackageName = trimlevel.TrimPackageName;
            oldTrimlevel.TwozoneAutomaticAC = trimlevel.TwozoneAutomaticAC;
            oldTrimlevel.WeightHook = trimlevel.WeightHook;
            context.SaveChanges();
        }
    }
}
