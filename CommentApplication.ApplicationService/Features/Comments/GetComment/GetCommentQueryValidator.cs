using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.ApplicationService.Features.Comments.GetComment
{
    public class GetCommentQueryValidator:AbstractValidator<GetCommentQuery>
    {
        public GetCommentQueryValidator()
        {
            RuleFor(c => c.Id)
            .NotNull()
            .NotEqual(Guid.Empty);
        }
    }
}
