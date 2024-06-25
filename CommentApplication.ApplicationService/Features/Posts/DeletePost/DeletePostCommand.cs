using CommentApplicatin.Domain.Events;
using CommentApplication.ApplicationService.Contracts.Persistence;
using CommentApplication.ApplicationService.Features.Comments.DeleteComment;
using CommentApplication.ApplicationService.Validation;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.ApplicationService.Features.Posts.DeletePost
{
    public class DeletePostCommand : IRequest<Result<Unit>>
    {
        public Guid Id { get; set; }
    }
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, Result<Unit>>
    {
        private readonly IPostRepository _postRepository;

        public DeletePostCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Result<Unit>> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetById(request.Id);
            if (post == null)
            {
                return Result.Fail(new NotFoundError($"Comment with id{request.Id}cannot be found"));
            }
            post.AddDomainEvent(EntityDeletedEvent.WithEntity(post));
            await _postRepository.Delete(post);

            return Result.Ok(Unit.Value);

        }
    }
}

