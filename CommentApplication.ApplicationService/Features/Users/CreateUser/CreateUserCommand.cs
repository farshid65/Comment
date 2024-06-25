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

namespace CommentApplication.ApplicationService.Features.Users.CreateUser
{
    public class CreateUserCommand:IRequest<Result<CreateUserCommandResponse>>
    {
        public string Name { get; set; }
    }
    public class CreateUserCommandHandler:IRequestHandler<CreateUserCommand, Result<CreateUserCommandResponse>> 
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<CreateUserCommandResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User { Id = Guid.NewGuid() };
            request.Adapt(user);

            user.AddDomainEvent(EntityCreatedEvent.WithEntity(user));
            user = await _userRepository.Add(user);

            var response = user.Adapt<CreateUserCommandResponse>();

            return Result.Ok(response);



        }
    }
}
