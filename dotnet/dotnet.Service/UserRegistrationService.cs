using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet.DataAccess;
using dotnet.DTO;

namespace dotnet.Service
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly IUserRegistrationRepository _userRepository;

        public UserRegistrationService(IUserRegistrationRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> CreateUserAsync(UserRegistrationDTO user)
        {
            // Check if email address is already in use
            var existingUser = await _userRepository.GetByEmailAsync(user.EmailAddress);
            if (existingUser != null)
            {
                throw new Exception("Email address is already in use");
            }

            // Create the user
            int userId = await _userRepository.CreateAsync(user);
            return userId;
        }

        public async Task<UserRegistrationDTO> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user;
        }

        public async Task<IEnumerable<UserRegistrationDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users;
        }

        public async Task<bool> UpdateUserAsync(UserRegistrationDTO user)
        {
            // Check if email address is already in use by another user
            var existingUser = await _userRepository.GetByEmailAsync(user.EmailAddress);
            if (existingUser != null && existingUser.Id != user.Id)
            {
                throw new Exception("Email address is already in use");
            }

            // Update the user
            bool isUpdated = await _userRepository.UpdateAsync(user);
            return isUpdated;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            bool isDeleted = await _userRepository.DeleteAsync(id);
            return isDeleted;
        }
    }
}