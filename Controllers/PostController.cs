using CommentApplication.ApplicationService.Features.Posts.ChangeContent;
using CommentApplication.ApplicationService.Features.Posts.CreatePost;
using CommentApplication.ApplicationService.Features.Posts.DeletePost;
using CommentApplication.ApplicationService.Features.Posts.GetPost;
using CommentApplication.ApplicationService.Features.Posts.GetPosts;
using CommentApplication.Extensions;
using CommentApplication.Persistence.Controllers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommentApplication.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]    
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [ApiConventionMethod(typeof(ApiConventions), nameof(ApiConventions.List))]
        [HttpGet(Name = "GetPosts")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetPostsQueryResponse>))]
        public async Task<ActionResult> GetPosts()
        {
            var result = await _mediator.Send(new GetPostsQuery());
            return result.ToHttpResponse();
        }
        [ApiConventionMethod(typeof(ApiConventions), nameof(ApiConventions.Get))]
        [HttpGet("{id:Guid}", Name = "GetCategory")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetPostsQueryResponse))]
        public async Task<ActionResult> Get(Guid id)
        {
            var result = await _mediator.Send(new GetUSerQuery { Id = id });
            return result.ToHttpResponse();
        }
        [ApiConventionMethod(typeof(ApiConventions), nameof(ApiConventions.Create))]
        [HttpPost(Name = "CreatePost")]
        public async Task<ActionResult> Create(CreatePostCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToCreatedHttpResponse();
        }
        [ApiConventionMethod(typeof(ApiConventions), nameof(ApiConventions.Update))]
        [HttpPost("ChangeContent", Name = "ChangePostContent")]
        public async Task<ActionResult> ChangeName(ChangeContenCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToHttpResponse();
        }
        [ApiConventionMethod(typeof(ApiConventions), nameof(ApiConventions.Delete))]
        [HttpDelete("{id:Guid}", Name = "DeletePost")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeletePostCommand { Id = id });
            return result.ToHttpResponse();
        }
    }
}
