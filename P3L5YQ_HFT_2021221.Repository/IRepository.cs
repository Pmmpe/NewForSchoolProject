using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3L5YQ_HFT_2021221.Repository
{
    public interface IRepository<T> where T : class
    {
        T GetOne(int searchedContractNumber);

        IQueryable<T> GetAll();

        public void Create(T generalItem);

        public T Read(int id);

        abstract public void Update(T generalItem, int id);

        public void Delete(int id);
    }
}
