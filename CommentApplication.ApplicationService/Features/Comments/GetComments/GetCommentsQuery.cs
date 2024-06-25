using CommentApplication.ApplicationService.Contracts.Persistence;
using FluentResults;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.ApplicationService.Features.Comments.GetComments
{
    public class GetCommentsQuery:IRequest<Result<IEnumerable<GetCommentsQueryResponse>>>
    {

    }
    public class GetCommentsQueriesHandler:IRequestHandler<GetCommentsQuery, Result<IEnumerable<GetCommentsQueryResponse>>>
    {
        private readonly ICommentRepository _commentRepository;

        public GetCommentsQueriesHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Result<IEnumerable<GetCommentsQueryResponse>>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            var comment = (await _commentRepository.ListAll()).OrderBy(x => x.Content);
            var response = comment.Adapt<IEnumerable<GetCommentsQueryResponse>>();

            return Result.Ok(response);
        }

       
    }
}
