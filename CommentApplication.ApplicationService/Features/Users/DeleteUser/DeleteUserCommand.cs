using CommentApplicatin.Domain.Events;
using CommentApplication.ApplicationService.Contracts.Persistence;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.ApplicationService.Features.Users.DeleteUser
{
    public class DeleteUserCommand:IRequest<Result<Unit>>
    {
        public Guid Id { get; set; }
    }
    public class DeleteUserCommandHandler:IRequestHandler<DeleteUserCommand, Result<Unit>> 
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<Unit>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id);
            if (user == null) 
            {
                return Result.Fail($"User with id {request.Id} cannot be found");
            }
            user.AddDomainEvent(EntityDeletedEvent.WithEntity(user));
            await _userRepository.Delete(user);

            return Result.Ok(Unit.Value);

        }
    }
}
