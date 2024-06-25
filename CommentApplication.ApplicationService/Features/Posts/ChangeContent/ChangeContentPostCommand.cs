using CommentApplication.ApplicationService.Contracts.Persistence;
using CommentApplication.ApplicationService.Validation;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.ApplicationService.Features.Posts.ChangeContent
{
    public class ChangeContenCommand : IRequest<Result<Unit>>
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
    }
    public class ChangeContentPostCommandHandler : IRequestHandler<ChangeContenCommand, Result<Unit>>
    {
        private readonly IPostRepository _postRepository;

        public ChangeContentPostCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Result<Unit>> Handle(ChangeContenCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetById(request.Id);

            if (post == null)
            {
                return Result.Fail(new NotFoundError($"Comment with Id {request.Id} cannot be found"));
            }
            post.Content = request.Content;
            await _postRepository.Update(post);
            return Result.Ok(Unit.Value);
        }
    }
}
