using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _entities;

        public Repository(AppDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public async Task Create(T entity)
        {
            if (entity == null) throw new ArgumentNullException();
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _entities.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<T> Get(int id)
        {
            T entity = await _entities.FindAsync(id) ?? throw new NullReferenceException();
            return entity;
        }

        public async Task<List<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<List<T>> FindAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _entities.Where(expression).ToListAsync();
        }

        public async Task Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException();

            _entities.Update(entity);

            await _context.SaveChangesAsync();


        }

        public async Task SoftDelete(T entity)
        {
            T? model = await _entities.FirstOrDefaultAsync(m=> m.Id == entity.Id);
            if(model == null) throw new NullReferenceException();

            model.SoftDeleted = true;

            _context.SaveChanges();
        }
    }
}
