using CommentApplicatin.Domain.Entities;
using CommentApplication.ApplicationService.Contracts.Persistence;
using CommentApplication.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.Persistence.Repositories
{
    public class CommentRepository:BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext dbContext):base(dbContext) 
        {
                
        }
    }
}
