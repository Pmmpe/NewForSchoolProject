namespace P3L5YQ_HFT_2021221.Logic
{
    using P3L5YQ_HFT_2021221.Models;
    using P3L5YQ_HFT_2021221.Repository;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class EngineLogic : IEngineLogic
    {
        IEngineRepository engineRepository;

        public EngineLogic(IEngineRepository engineRepo)
        {
            this.engineRepository = engineRepo;
        }
        public bool Create(Engine engine)
        {

                if (engine.Enginename == null)
                {
                    throw new MissingFieldException("Component is missing!");
                }
                else
                {
                    engineRepository.Create(engine);
                return true;
                }
        }

        public bool Delete(int id)
        {
            try
            {
                engineRepository.Delete(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Engine Read(int id)
        {
            return engineRepository.Read(id);
        }

        public bool Update(Engine engine, int id)
        {
            try
            {
                engineRepository.Update(engine, id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public IEnumerable<Engine> ReadAll()
        {
            return engineRepository.GetAll();
        }
    }
}
