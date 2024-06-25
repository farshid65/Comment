using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.ApplicationService.Features.Posts.CreatePost
{
    public class CreatePostCommandValidator:AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(c => c.Content)
                .NotEmpty()
                .MinimumLength(10000);
        }
    }
}
