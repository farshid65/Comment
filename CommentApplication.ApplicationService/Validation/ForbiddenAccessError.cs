using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.ApplicationService.Validation
{
    public class ForbiddenAccessError : Error
    {
        public ForbiddenAccessError(string message):base(message)
        {
            
        }
    }
}
