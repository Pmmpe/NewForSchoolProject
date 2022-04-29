using Microsoft.EntityFrameworkCore;
using P3L5YQ_HFT_2021221.Data;
using System.Linq;

namespace P3L5YQ_HFT_2021221.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        public Repository(DealershipDbContext context)
        {
            this.context = context;
        }

        protected DbContext context;

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }
        public void Create(T generalItem)
        {
            this.context.Add(generalItem);
            this.context.SaveChanges();
        }
        public T Read(int id)
        {
            return this.GetOne(id);
        }
        virtual public void Update(T generalItem, int id)
        {
        }
        public void Delete(int id)
        {
            T generalItem = GetOne(id);
            this.context.Set<T>().Remove(generalItem);
            this.context.SaveChanges();
        }
        public T GetOne(int searchedId)
        {
            return this.context.Set<T>().Find(searchedId);
        }
    }
}
