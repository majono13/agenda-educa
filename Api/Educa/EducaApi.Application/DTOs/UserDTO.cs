using EducaApi.Domain.Entities;

namespace EducaApi.Application.DTOs
{
    public class UserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public dynamic? Token { get; set; }
    }
}
