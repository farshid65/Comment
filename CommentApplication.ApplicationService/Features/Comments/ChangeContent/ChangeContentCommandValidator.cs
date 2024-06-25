using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.ApplicationService.Features.Comments.ChangeContent
{
    public class ChangeContentCommandValidator:AbstractValidator<ChangeContentCommand>
    {
        public ChangeContentCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotNull()
                .NotEqual(Guid.Empty);
            RuleFor(p => p.Content)
                .NotEmpty()
                .MinimumLength(250);
                
            
        }
    }
}
