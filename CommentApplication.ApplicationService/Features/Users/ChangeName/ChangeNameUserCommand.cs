using CommentApplication.ApplicationService.Contracts.Persistence;
using CommentApplication.ApplicationService.Validation;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.ApplicationService.Features.Users.ChangeName
{
    public class ChangeNameUserCommand:IRequest<Result<Unit>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class ChangeNameUserCommandHandler:IRequestHandler<ChangeNameUserCommand,Result<Unit>>
    {
        private readonly IUserRepository _userRepository;

        public ChangeNameUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<Unit>> Handle(ChangeNameUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id);
            if(user==null)
            {
                Result.Fail(new NotFoundError($"User with id {request.Id} cannot be found"));
            }
            user.LastName = request.Name;
            await _userRepository.Update(user);

            return Result.Ok(Unit.Value);
        }
    }
}
