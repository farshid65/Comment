using CommentApplication.ApplicationService.Features.Posts.CreatePost;
using CommentApplication.ApplicationService.Features.Posts.DeletePost;
using CommentApplication.ApplicationService.Features.Posts.GetPost;
using CommentApplication.ApplicationService.Features.Posts.GetPosts;
using CommentApplication.ApplicationService.Features.Users.ChangeName;
using CommentApplication.ApplicationService.Features.Users.CreateUser;
using CommentApplication.ApplicationService.Features.Users.DeleteUser;
using CommentApplication.ApplicationService.Features.Users.GetUsers;
using CommentApplication.Extensions;
using CommentApplication.Persistence.Controllers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommentApplication.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [ApiConventionMethod(typeof(ApiConventions), nameof(ApiConventions.List))]
        [HttpGet(Name = "GetPosts")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetUsersQueryResponse>))]
        public async Task<ActionResult> GetUsers()
        {
            var result = await _mediator.Send(new GetUsersQuery());
            return result.ToHttpResponse();
        }
        [ApiConventionMethod(typeof(ApiConventions), nameof(ApiConventions.Get))]
        [HttpGet("{id:Guid}", Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetPostsQueryResponse))]
        public async Task<ActionResult> Get(Guid id)
        {
            var result = await _mediator.Send(new GetUSerQuery { Id = id });
            return result.ToHttpResponse();
        }
        [ApiConventionMethod(typeof(ApiConventions), nameof(ApiConventions.Create))]
        [HttpPost(Name = "CreateComment")]
        public async Task<ActionResult> Create(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToCreatedHttpResponse();
        }
        [ApiConventionMethod(typeof(ApiConventions), nameof(ApiConventions.Update))]
        [HttpPost("ChangeName", Name = "ChangeNameUser")]
        public async Task<ActionResult> ChangeName(ChangeNameUserCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToHttpResponse();
        }
        [ApiConventionMethod(typeof(ApiConventions), nameof(ApiConventions.Delete))]
        [HttpDelete("{id:Guid}", Name = "DeleteUser")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteUserCommand { Id = id });
            return result.ToHttpResponse();
        }
    }


}

