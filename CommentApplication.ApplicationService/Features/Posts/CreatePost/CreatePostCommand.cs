using CommentApplicatin.Domain.Entities;
using CommentApplicatin.Domain.Events;
using CommentApplication.ApplicationService.Contracts.Persistence;
using CommentApplication.ApplicationService.Validation;
using FluentResults;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.ApplicationService.Features.Posts.CreatePost
{
    public class CreatePostCommand:IRequest<Result<CreatePostommandResponse>>
    {
        public string? Content { get; set; }
    }
    public class CreatePostCommandHandler:IRequestHandler<CreatePostCommand, Result<CreatePostommandResponse>>
    {
        private readonly IPostRepository _postRepository;

        public CreatePostCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Result<CreatePostommandResponse>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = new Post{Id=Guid.NewGuid()};
            request.Adapt(post);

            post.AddDomainEvent(EntityCreatedEvent.WithEntity(post));
            post = await _postRepository.Add(post);

            var response = post.Adapt<CreatePostommandResponse>();
            return Result.Ok(response);

            
        }
    }
}
