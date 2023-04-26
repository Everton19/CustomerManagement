using CustomerManagement.Entity;
using CustomerManagement.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppCustomerContext _context;
        private readonly Unit _unit;

        public Repository(AppCustomerContext context)
        {
            _context = context;
            _unit = new Unit(context);
        }

        public TEntity GetById(int id)
        {
            var query = _context.Set<TEntity>().Where(c => c.Id == id).AsNoTracking();

            if (query.Any())
                return query.FirstOrDefault();

            return null;
        }

        public IEnumerable<TEntity> GetAll()
        {
            var query = _context.Set<TEntity>().AsNoTracking();

            if (query.Any())
                return query.AsNoTracking().ToList();

            return new List<TEntity>();
        }

        public TEntity Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _unit.Commit();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _unit.Commit();
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _unit.Commit();
            return entity;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var query = _context.Set<TEntity>().Where(c => c.Id == id);

            if (await query.AnyAsync())
                return await query.FirstOrDefaultAsync();

            return null;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var query = _context.Set<TEntity>().AsNoTracking();

            if (await query.AnyAsync())
                return await query.ToListAsync();
            
            return new List<TEntity>();
           
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _unit.CommitAsync();
            return entity;
        }        
    }
}
