using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.ApplicationService.Features.Comments.DeleteComment
{
    internal class DeleteCommentCommandValidator:AbstractValidator<DeleteCommentCommand>
    {
        public DeleteCommentCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotNull()
                .NotEqual(Guid.Empty);

        }
    }
}
