using CommentApplication.ApplicationService.Features.Comments.CreateComment;
using CommentApplication.ApplicationService.Features.Comments.DeleteComment;
using CommentApplication.ApplicationService.Features.Comments.GetComment;
using CommentApplication.ApplicationService.Features.Comments.GetComments;
using CommentApplication.ApplicationService.Features.Posts.ChangeContent;
using CommentApplication.ApplicationService.Features.Posts.CreatePost;
using CommentApplication.ApplicationService.Features.Posts.DeletePost;
using CommentApplication.ApplicationService.Features.Posts.GetPost;
using CommentApplication.ApplicationService.Features.Posts.GetPosts;
using CommentApplication.Extensions;
using CommentApplication.Persistence.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CommentApplication.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [ApiConventionMethod(typeof(ApiConventions), nameof(ApiConventions.List))]
        [HttpGet(Name = "GetComment")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetCommentsQueryResponse>))]
        public async Task<ActionResult> GetComments()
        {
            var result = await _mediator.Send(new GetCommentsQuery());
            return result.ToHttpResponse();
        }
        [ApiConventionMethod(typeof(ApiConventions), nameof(ApiConventions.Get))]
        [HttpGet("{id:Guid}", Name = "GetComment")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCommentsQueryResponse))]
        public async Task<ActionResult> Get(Guid id)
        {
            var result = await _mediator.Send(new GetCommentQuery { Id = id });
            return result.ToHttpResponse();
        }
        [ApiConventionMethod(typeof(ApiConventions), nameof(ApiConventions.Create))]
        [HttpPost(Name = "CreateComment")]
        public async Task<ActionResult> Create(CreateCommentCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToCreatedHttpResponse();
        }
        [ApiConventionMethod(typeof(ApiConventions), nameof(ApiConventions.Update))]
        [HttpPost("ChangeContent", Name = "ChangeContent")]
        public async Task<ActionResult> ChangeName(ChangeContenCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToHttpResponse();
        }
        [ApiConventionMethod(typeof(ApiConventions), nameof(ApiConventions.Delete))]
        [HttpDelete("{id:Guid}", Name = "DeleteComment")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteCommentCommand { Id = id });
            return result.ToHttpResponse();
        }
    }
}
