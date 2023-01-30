
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

        /** Método assíncrono para criar novo usuário **/
        public async Task<User> CreateUserAsync(User user)
        {
            var newUserWithPasswordHash = HashPassword(user);

            await _db.Users.AddAsync(newUserWithPasswordHash);
            _db.SaveChanges();
            return newUserWithPasswordHash;
        }

        //Método privado para realizar hash da senha enviada pelo front
        private User HashPassword(User user)
        {
            var passwordHash = new PasswordHasher<User>();
            return new User(user.Email, passwordHash.HashPassword(user, user.Password));
        }

        /** Método assíncrono para buscar usuário pelo e-mail **/
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        /** Método assíncrono para logar usuário e retornar dadis do professor vinculado ao login **/
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
