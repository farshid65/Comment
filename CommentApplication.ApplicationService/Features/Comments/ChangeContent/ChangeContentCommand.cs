using CommentApplication.ApplicationService.Contracts.Persistence;
using CommentApplication.ApplicationService.Validation;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.ApplicationService.Features.Comments.ChangeContent
{
    public class ChangeContentCommand:IRequest<Result<Unit>>
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
    }
    public class ChangeCommentContentCommandHandler:IRequestHandler<ChangeContentCommand, Result<Unit>>
    {
        private readonly ICommentRepository _commentRepository;

        public ChangeCommentContentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Result<Unit>> Handle(ChangeContentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetById(request.Id);

            if(comment == null) 
            {
                return Result.Fail(new NotFoundError($"Comment with Id {request.Id} cannot be found"));
            }
            comment.Content = request.Content;
            await _commentRepository.Update(comment);
            return Result.Ok(Unit.Value);
        }
    }
}
