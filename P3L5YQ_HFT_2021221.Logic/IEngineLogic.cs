namespace P3L5YQ_HFT_2021221.Logic
{
    using P3L5YQ_HFT_2021221.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface IEngineLogic : IGeneralLogic
    {
        public bool Create(Engine engine);
        public bool Delete(int id);
        public Engine Read(int id);
        public bool Update(Engine engine, int id);
        public IEnumerable<Engine> ReadAll();

    }
}