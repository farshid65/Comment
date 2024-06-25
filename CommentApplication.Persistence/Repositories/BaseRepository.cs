using CommentApplicatin.Domain.Common;
using CommentApplication.ApplicationService.Contracts.Persistence;
using CommentApplication.ApplicationService.Models;
using CommentApplication.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<bool> Exists(Guid id)
        {
            bool exists = await _dbContext.Set<T>().AnyAsync(c => c.Id == id);
            return exists;
           
        }

        public virtual async Task<T?> GetById(Guid id)
        {
            T? t = await _dbContext.Set<T>().FindAsync(id);
            return t;
        }

        public async Task<ApplicationService.Models.PaginatedList<T>> GetPagedReponse(int page, int size)
        {
            var queryable = _dbContext.Set<T>().AsQueryable();
            var items = await queryable.Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
            var count = await queryable.CountAsync();
            return new PaginatedList<T>(items, count, page, size);
        }

        public async Task<IReadOnlyList<T>> ListAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
