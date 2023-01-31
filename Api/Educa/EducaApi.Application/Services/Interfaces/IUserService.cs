using EducaApi.Application.DTOs;

namespace EducaApi.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResultService<UserDTO>> CreateUserAsync(UserDTO userDTO);
        Task<ResultService<TeacherDto>> LoginAsync(UserDTO userDTO);
        Task<ResultService> UpdateUserAsync(UserDTO userDTO);
    }
}
