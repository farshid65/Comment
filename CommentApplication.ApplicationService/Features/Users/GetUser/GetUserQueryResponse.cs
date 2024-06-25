using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.ApplicationService.Features.Users.GetUser
{
    public class GetUserQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
