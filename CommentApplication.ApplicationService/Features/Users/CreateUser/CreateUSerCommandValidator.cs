using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.ApplicationService.Features.Users.CreateUser
{
    public class CreateUSerCommandValidator:AbstractValidator<CreateUserCommand>
    {
        public CreateUSerCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .MaximumLength(250);
                
                
        }
    }
}
