
using EducaApi.Domain.Entities;
using EducaApi.Domain.Repositories;
using EducaApi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EducaApi.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        #region Create user
        /** Método assíncrono para criar novo usuário **/
        public async Task<User> CreateUserAsync(User user)
        {

            await _db.Users.AddAsync(user);
            _db.SaveChanges();
            return user;
        }
        #endregion

        #region Get user by email
        /** Método assíncrono para buscar usuário pelo e-mail **/
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
        #endregion

        #region Edit password
        /** Método assíncrono para editar professor **/
        public async Task UpdateUserAsync(User user)
        {
            _db.Update(user);
            await _db.SaveChangesAsync();
        }
        #endregion

        #region Get user email by token

        /** Método assíncrono para recuperar usuário através do token **/
        public async Task<string> GetUserEmailByToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken securityToken = tokenHandler.ReadJwtToken(token);
            IEnumerable<Claim> claims = securityToken.Claims;

            foreach (Claim claim in claims)
            {
                if (claim.Type == "Email") return claim.Value;
            };

            return null;
        }
        #endregion
    }
}
