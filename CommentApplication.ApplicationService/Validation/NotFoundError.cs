using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.ApplicationService.Validation
{
    public class NotFoundError:Error
    {
        public NotFoundError(string message):base(message) 
        {
        }
    }
}
