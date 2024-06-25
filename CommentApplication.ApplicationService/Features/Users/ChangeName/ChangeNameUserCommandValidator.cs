using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.ApplicationService.Features.Users.ChangeName
{
    public class ChangeNameUserCommandValidator:AbstractValidator<ChangeNameUserCommand>
    {
        public ChangeNameUserCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotNull()
                .NotEqual(Guid.Empty);

            RuleFor(c => c.Name)
                .NotEmpty()
                .MaximumLength(250);
                

        }
    }
}
