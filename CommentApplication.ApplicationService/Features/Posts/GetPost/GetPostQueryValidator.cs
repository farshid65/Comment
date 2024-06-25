using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.ApplicationService.Features.Posts.GetPost
{
    public class GetPostQueryValidator:AbstractValidator<GetUSerQuery>
    {
        public GetPostQueryValidator()
        {
            RuleFor(c => c.Id)
                .NotNull()
                .NotEqual(Guid.Empty);
        }
    }
}
