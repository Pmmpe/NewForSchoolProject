namespace P3L5YQ_HFT_2021221.Logic
{
    using P3L5YQ_HFT_2021221.Models;
    using P3L5YQ_HFT_2021221.Repository;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class TrimLevelLogic : ITrimLevelLogic
    {
        ITrimLevelRepository trimLevelRepository;

        public TrimLevelLogic(ITrimLevelRepository trimLevelRepo)
        {
            this.trimLevelRepository = trimLevelRepo;
        }
        public bool Create(TrimLevel trimLevel)
        {
                if (trimLevel.TrimPackageName == null)
                {
                    throw new MissingFieldException("Component is missing!");
                }
                else
                {
                    trimLevelRepository.Create(trimLevel);
                return true;
                }
        }

        public bool Delete(int id)
        {
            try
            {
                trimLevelRepository.Delete(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }           
        }

        public TrimLevel Read(int id)
        {
            return trimLevelRepository.Read(id);
        }

        public bool Update(TrimLevel trimlevel, int id)
        {
            try
            {
                trimLevelRepository.Update(trimlevel, id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<TrimLevel> ReadAll()
        {
            return trimLevelRepository.GetAll();
        }
    }
}

