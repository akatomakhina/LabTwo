using AutoMapper;
using GamesProjectWeb.DataAccess.Common.Models;
using GamesProjectWeb.DataAccess.Common.Repositories;
using GamesProjectWeb.Logic.Common.Exceptions;
using GamesProjectWeb.Logic.Common.Models;
using GamesProjectWeb.Logic.Common.Services;
using System;
using System.Threading.Tasks;

namespace GamesProjectWeb.Logic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<User> CreateUserAsync()
        {
            var newUser = new DbUser();

            var addedUser = await _userRepository.AddUserAsync(newUser).ConfigureAwait(false);
            return Mapper.Map<User>(addedUser);
        }

        public async Task DeleteUserAsync(int userId)
        {
            var dbUser = await _userRepository.GetUserByIdAsync(userId).ConfigureAwait(false);

            if (ReferenceEquals(dbUser, null))
            {
                throw new RequestedResourceNotFoundException($"User with id {userId}");
            }

            var deletedUser = await _userRepository.DeleteUserAsync(dbUser).ConfigureAwait(false);
            throw new NotImplementedException();
        }
    }
}
