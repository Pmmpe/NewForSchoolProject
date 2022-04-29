namespace P3L5YQ_HFT_2021221.Logic
{
    using P3L5YQ_HFT_2021221.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface ITrimLevelLogic : IGeneralLogic
    {
        public bool Create(TrimLevel trimLevel);
        public bool Delete(int id);
        public TrimLevel Read(int id);
        public bool Update(TrimLevel trimlevel, int id);
        public IEnumerable<TrimLevel> ReadAll();
    }
}
