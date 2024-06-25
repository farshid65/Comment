using CommentApplication.ApplicationService.Contracts.Persistence;
using FluentResults;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.ApplicationService.Features.Users.GetUser
{
    public class GetUserQuery:IRequest<Result<GetUserQueryResponse>>
    {
        public Guid Id { get; set; }
    }
    public class GetUserQueryHandle : IRequestHandler<GetUserQuery, Result<GetUserQueryResponse>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandle(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result<GetUserQueryResponse>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id);
                if(user == null)
            {
                Result.Fail($"User with id {request.Id} cannot be found");
            }
                var response = user.Adapt<GetUserQueryResponse>();
            return Result.Ok(response);
        }
    }
}
