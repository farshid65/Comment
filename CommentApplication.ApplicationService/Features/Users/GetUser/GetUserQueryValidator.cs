using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.ApplicationService.Features.Users.GetUser
{
    public class GetUserQueryValidator:AbstractValidator<GetUserQuery>
    {
        public GetUserQueryValidator()
        {
            RuleFor(c => c.Id)
                .NotNull()
                .NotEqual(Guid.Empty);
        }
    }
}
