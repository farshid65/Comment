using CommentApplication.ApplicationService.Contracts.Persistence;
using FluentResults;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.ApplicationService.Features.Posts.GetPosts
{
    public class GetPostsQuery:IRequest<Result<IEnumerable<GetPostsQueryResponse>>>
    {

    }
    public class GetPostsQueryHandler:IRequestHandler<GetPostsQuery, Result<IEnumerable<GetPostsQueryResponse>>>
    {
        private readonly IPostRepository _postRepository;

        public GetPostsQueryHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Result<IEnumerable<GetPostsQueryResponse>>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            var posts = (await _postRepository.ListAll()).OrderBy(x => x.Content);
            var response = posts.Adapt<IEnumerable<GetPostsQueryResponse>>();

            return Result.Ok(response);
        }
    }
}
