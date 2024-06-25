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

namespace CommentApplication.ApplicationService.Features.Comments.GetComment
{
    public class GetCommentQuery:IRequest<Result<GetCommentQueryResponse>>
    {
        public Guid Id { get; set; }


    }
    public class GetCommentQueryHandler:IRequestHandler<GetCommentQuery,Result<GetCommentQueryResponse>>
    {
        private readonly ICommentRepository _commentRepository;

        public GetCommentQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Result<GetCommentQueryResponse>> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetById(request.Id);

            if (comment == null) 
            {
                return Result.Fail(new NotFoundError($"Comment with id {request.Id} cannot be found"));
            }
            var response = comment.Adapt<GetCommentQueryResponse>();

            return Result.Ok(response);
        }
    }
}
