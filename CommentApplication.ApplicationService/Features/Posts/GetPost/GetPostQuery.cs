using CommentApplication.ApplicationService.Contracts.Persistence;
using FluentResults;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.ApplicationService.Features.Posts.GetPost
{
    public class GetUSerQuery:IRequest<Result<GetPostQueyResponse>>
    {
        public Guid Id { get; set; }
    }
    public class GetPostQueryHandler:IRequestHandler<GetUSerQuery, Result<GetPostQueyResponse>>
    {
        private readonly IPostRepository _postRepository;

        public GetPostQueryHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Result<GetPostQueyResponse>> Handle(GetUSerQuery request, CancellationToken cancellationToken)
        {
            var post = _postRepository.GetById(request.Id);
            if(post == null)
            {
                return Result.Fail($"Post with id {request.Id} cannot be found");
            }
            var response = post.Adapt<GetPostQueyResponse>();
            return Result.Ok(response);
        }
    }
}
