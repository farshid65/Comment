using CommentApplicatin.Domain.Events;
using CommentApplication.ApplicationService.Contracts.Persistence;
using CommentApplication.ApplicationService.Validation;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.ApplicationService.Features.Comments.DeleteComment
{
    public class DeleteCommentCommand:IRequest<Result<Unit>>
    {
        public Guid Id { get; set; }
    }
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, Result<Unit>>
    {
        private readonly ICommentRepository _commentRepository;

        public DeleteCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Result<Unit>> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetById(request.Id);
            if (comment == null) 
            {
                return Result.Fail(new NotFoundError($"Comment with id{request.Id}cannot be found"));
            }
            comment.AddDomainEvent(EntityDeletedEvent.WithEntity(comment));
            await _commentRepository.Delete(comment);

            return Result.Ok(Unit.Value);

        }
    }
}
