using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet.DataAccess;
using dotnet.DTO;

namespace dotnet.Service
{
    public class UserService : IUserService
    {
        private readonly IUserModelRepository _userRepository;

        public UserService(IUserModelRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> CreateUser(UserDto user)
        {
            var userModel = MapUserDtoToModel(user);
            return await _userRepository.CreateUser(userModel);
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var userModel = await _userRepository.GetUserById(id);
            return MapUserModelToDto(userModel);
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            var userModels = await _userRepository.GetAllUsers();
            return MapUserModelsToDtos(userModels);
        }

        public async Task<int> UpdateUser(UserDto user)
        {
            var userModel = MapUserDtoToModel(user);
            return await _userRepository.UpdateUser(userModel);
        }

        public async Task<int> DeleteUser(int id)
        {
            return await _userRepository.DeleteUser(id);
        }

        private UserModel MapUserDtoToModel(UserDto userDto)
        {
            return new UserModel
            {
                Id = userDto.Id,
                Username = userDto.Username,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                EmailAddress = userDto.EmailAddress,
                MobileNumber = userDto.MobileNumber,
                PhoneNumber = userDto.PhoneNumber,
                Role = userDto.Role,
                Level = userDto.Level,
                Notes = userDto.Notes,
                IsActive = userDto.IsActive
            };
        }

        private UserDto MapUserModelToDto(UserModel userModel)
        {
            return new UserDto
            {
                Id = userModel.Id,
                Username = userModel.Username,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                EmailAddress = userModel.EmailAddress,
                MobileNumber = userModel.MobileNumber,
                PhoneNumber = userModel.PhoneNumber,
                Role = userModel.Role,
                Level = userModel.Level,
                Notes = userModel.Notes,
                IsActive = userModel.IsActive
            };
        }

        private List<UserDto> MapUserModelsToDtos(List<UserModel> userModels)
        {
            var userDtos = new List<UserDto>();
            foreach (var userModel in userModels)
            {
                userDtos.Add(MapUserModelToDto(userModel));
            }
            return userDtos;
        }
    }
}