using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.ApplicationService.Features.Posts.ChangeContent
{
    public class ChangeContentCommandValidator:AbstractValidator<ChangeContenCommand>
    {
        public ChangeContentCommandValidator()
        {
            RuleFor(p => p.Content)
           .NotEmpty()
           .MaximumLength(10000);
        }
    }
}
