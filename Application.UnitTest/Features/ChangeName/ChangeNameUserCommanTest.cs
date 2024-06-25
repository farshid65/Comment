using AutoFixture;
using AutoFixture.AutoMoq;
using CommentApplicatin.Domain.Entities;
using CommentApplication.ApplicationService.Contracts.Persistence;
using CommentApplication.ApplicationService.Features.Users.ChangeName;
using Mapster;
using MediatR;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTest.Features.ChangeName
{
    public class ChangeNameUserCommanTest
    {
        private IFixture _fixture;
        private Mock<IUserRepository> _userRepository;
        private ChangeNameUserCommandHandler _sut;

        public ChangeNameUserCommanTest()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _userRepository = _fixture.Freeze<Mock<IUserRepository>>();
            _sut = _fixture.Create<ChangeNameUserCommandHandler>();
        }
        [Fact]
        public async Task ChangeUserName_WithExistingUserName_ReturnsSuccess()
        {
            var changeNameUserCommand = new ChangeNameUserCommand
            {
                Id = Guid.NewGuid(),
                Name = "Test",
            };

            var user = changeNameUserCommand.Adapt<User>();

            _userRepository.Setup(c => c.GetById(changeNameUserCommand.Id)).ReturnsAsync(user).Verifiable();

            var result = await _sut.Handle(changeNameUserCommand, CancellationToken.None);

            result.ShouldNotBeNull();
            result.IsSuccess.ShouldBeTrue();
            result.Value.ShouldBe(Unit.Value);
            _userRepository.Verify(c => c.GetById(changeNameUserCommand.Id), Times.Once());
            _userRepository.Verify(c => c.Update(user), Times.Once());

        }

        [Fact]
        public async Task ChangeUserName_WithExistingUserName_ReturnsFailure()
        {
            var changeNameUserCommand = new ChangeNameUserCommand
            {
                Id = Guid.NewGuid(),
                Name = "Test"
            };
            var user = changeNameUserCommand.Adapt<User>();

            _userRepository.Setup(c => c.GetById(changeNameUserCommand.Id))
                .ReturnsAsync(null as User).Verifiable();

            var result = await _sut.Handle(changeNameUserCommand, CancellationToken.None);

            result.ShouldNotBeNull();
            result.IsFailed.ShouldBeFalse();
            result.Errors.Any(c => c.Message == $"User with id {changeNameUserCommand.Id} cannot be found").ShouldBeTrue();
            _userRepository.Verify(c => c.GetById(changeNameUserCommand.Id), Times.Once());
            _userRepository.Verify(c=> c.Update(user), Times.Never);
        }
    }
}
