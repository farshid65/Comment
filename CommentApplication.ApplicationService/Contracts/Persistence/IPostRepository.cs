using CommentApplicatin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.ApplicationService.Contracts.Persistence
{
    public interface IPostRepository:IAsyncRepository<Post>
    {
    }
}
