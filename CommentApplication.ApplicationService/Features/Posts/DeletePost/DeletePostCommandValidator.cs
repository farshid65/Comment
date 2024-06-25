using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.ApplicationService.Features.Posts.DeletePost
{
    public class DeletePostCommandValidator:AbstractValidator<DeletePostCommand>
    {
        public DeletePostCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotNull()
                .NotEqual(Guid.Empty);
                
        }
    }
}
