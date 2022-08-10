using Authentication.Application.Commands.User;
using Authentication.Application.Mappers.User;
using Authentication.Application.Responses;
using Authentication.Core.Entities;
using Authentication.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Authentication.Application.Handlers.CommandHandlers.User
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserResponse>
    {
        private IUserRepository _userRepo;
        public CreateUserHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<UserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userEntitiy = UserMapper.Mapper.Map<Register>(request);
            if (userEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }

            var newUser = await _userRepo.AddUserAsync(userEntitiy);
            var userResponse = UserMapper.Mapper.Map<UserResponse>(newUser);
            return userResponse;
        }
    }
}
