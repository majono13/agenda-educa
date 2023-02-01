using EducaApi.Domain.Authentication;
using EducaApi.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EducaApi.Infra.Data.Authentication
{
    public class TokenGenerator : ITokenGenerator
    {
        public dynamic Generator(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("Email", user.Email),
            };

            var expires = DateTime.Now.AddDays(45);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("kjdf2i235wqiuyasjh1o387465kqw219jKJtRERsoihoeftrqscjlqd"));
            var tokenDat = new JwtSecurityToken(
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                expires: expires,
                claims: claims
                );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenDat);
            return new
            {
                access_token = token,
                expirations = expires
            };
        }
    }
}
