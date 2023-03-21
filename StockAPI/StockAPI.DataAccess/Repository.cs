using Microsoft.EntityFrameworkCore;
using StockAPI.DataAccess.Entities;

namespace StockAPI.DataAccess
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly StockApiStorageContext context;
        private DbSet<T> entities;

        public Repository(StockApiStorageContext _context) 
        {
            this.context = _context;
            entities = context.Set<T>();
        }
        public Task<List<T>> GetAll()
        {
            return entities.ToListAsync();
        }

        public Task<T> GetById(int id)
        {
            return entities.SingleOrDefaultAsync(s => s.Id == id);
        }

        public Task Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Add(entity);
            return context.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Update(entity);
            return context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            T entity = entities.SingleOrDefault(s => s.Id == id);
            entities.Remove(entity);
            await context.SaveChangesAsync();
        }
    }

    
}

