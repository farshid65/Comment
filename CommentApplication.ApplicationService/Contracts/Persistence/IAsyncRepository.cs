using CommentApplication.ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.ApplicationService.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T?> GetById(Guid id);

        Task<bool> Exists(Guid id);

        Task<IReadOnlyList<T>> ListAll();

        Task<T> Add(T entity);

        Task Update(T entity);

        Task Delete(T entity);

        Task<PaginatedList<T>> GetPagedReponse(int page, int size);
    }
}
