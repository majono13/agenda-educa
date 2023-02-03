using EducaApi.Domain.Entities;

namespace EducaApi.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<User> CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task<string> GetUserEmailByToken(string token);

    }
}
