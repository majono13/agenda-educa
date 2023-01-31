
using EducaApi.Domain.Entities;
using EducaApi.Domain.Repositories;
using EducaApi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EducaApi.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        /** Método assíncrono para criar novo usuário **/
        public async Task<User> CreateUserAsync(User user)
        {

            await _db.Users.AddAsync(user);
            _db.SaveChanges();
            return user;
        }

        /** Método assíncrono para buscar usuário pelo e-mail **/
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        /** Método assíncrono para editar professor **/
        public async Task UpdateUserAsync(User user)
        {
            _db.Update(user);
            await _db.SaveChangesAsync();
        }
    }
}
