using CommentApplicatin.Domain.Entities;
using CommentApplicatin.Domain.Events;
using CommentApplication.ApplicationService.Contracts.Persistence;
using FluentResults;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.ApplicationService.Features.Comments.CreateComment
{
    public class CreateCommentCommand:IRequest<Result<CreateCommentCommandResponse>>
    {
        public string? Content { get; set; } = default;
    }
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Result<CreateCommentCommandResponse>>
    {
        private readonly ICommentRepository _commentRepository;

        public CreateCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task<Result<CreateCommentCommandResponse>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new Comment { Id=Guid.NewGuid() };
            request.Adapt(comment);

            comment.AddDomainEvent(EntityCreatedEvent.WithEntity(comment));

            comment = await _commentRepository.Add(comment);

            var response = comment.Adapt<CreateCommentCommandResponse>();

            return Result.Ok(response);
        }
    }
}
