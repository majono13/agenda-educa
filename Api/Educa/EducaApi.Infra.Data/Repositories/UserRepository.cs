
using EducaApi.Domain.Entities;
using EducaApi.Domain.Repositories;
using EducaApi.Infra.Data.Context;
using Microsoft.AspNetCore.Identity;
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

        public async Task<User> CreateUserAsync(User user)
        {
            var newUserWithPasswordHash = HashPassword(user);

            await _db.Users.AddAsync(newUserWithPasswordHash);
            _db.SaveChanges();
            return newUserWithPasswordHash;
        }

        private User HashPassword(User user)
        {
            var passwordHash = new PasswordHasher<User>();
            return new User(user.Email, passwordHash.HashPassword(user, user.Password));
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Teacher> LoginAsync(User user)
        {
            //Verifica se existe usuário com email enviado
            var userDb = await GetUserByEmailAsync(user.Email);

            if (userDb != null)
            {
                //Faz hash para validar a senha enviada
                //Se a senha bater, devolve a entidade teacher, do contrário devolve nulo
                var passwordHash = new PasswordHasher<User>();
                var status = passwordHash.VerifyHashedPassword(user, userDb.Password, user.Password);

                switch (status)
                {
                    case PasswordVerificationResult.Success:
                        return userDb.Teacher;

                    case PasswordVerificationResult.Failed:
                        return null;
                }
            }

            return null;

        }
    }
}
