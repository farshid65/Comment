using CommentApplication.ApplicationService.Contracts.Persistence;
using FluentResults;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.ApplicationService.Features.Users.GetUsers
{
    public class GetUsersQuery:IRequest<Result<IEnumerable<GetUsersQueryResponse>>>
    {
        
    }
    public class GetUsersQueryHandler:IRequestHandler<GetUsersQuery, Result<IEnumerable<GetUsersQueryResponse>>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<IEnumerable<GetUsersQueryResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var user = (await _userRepository.ListAll()).OrderBy(x => x.LastName);

            var response = user.Adapt<IEnumerable<GetUsersQueryResponse>>();
           return Result.Ok(response);
        }
    }
}
