using Authentication.Application.Mappers.User;
using Authentication.Application.Queries;
using Authentication.Application.Responses;
using Authentication.Core.Entities;
using Authentication.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Authentication.Application.Handlers.QueryHandlers
{
    public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, List<UserResponse>>
    {
        private IUserRepository _userRepo;
        public GetAllUserHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<List<UserResponse>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = (List<AppUser>)await _userRepo.GetAllUserAsync();
            var usersResponse = UserMapper.Mapper.Map<List<UserResponse>>(users);
            return usersResponse;
        }
    }
}
