using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.ApplicationService.Features.Users.CreateUser
{
    public class CreateUserCommandResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
