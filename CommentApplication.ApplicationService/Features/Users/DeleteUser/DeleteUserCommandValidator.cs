using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.ApplicationService.Features.Users.DeleteUser
{
    public class DeleteUserCommandValidator:AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(c => c.Id)
            .NotNull()
            .NotEqual(Guid.Empty);
        }
    }
}
