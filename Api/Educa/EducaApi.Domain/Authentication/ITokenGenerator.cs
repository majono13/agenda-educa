using EducaApi.Domain.Entities;

namespace EducaApi.Domain.Authentication
{
    public interface ITokenGenerator
    {
        dynamic Generator(User user);
    }
}
