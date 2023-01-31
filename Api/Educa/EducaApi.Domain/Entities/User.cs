using EducaApi.Domain.Validations;

namespace EducaApi.Domain.Entities
{
    public class User
    {
        public string Email { get; private set; }
        public string Password { get; set; }
        public virtual Teacher Teacher { get; private set; }

        public User()
        {}

        public User(string email, string password)
        {
            Validation(email, password);
        }

        private void Validation(string email, string password)
        {
            DomainValidationException.When(string.IsNullOrEmpty(email), "Email deve ser informado");
            DomainValidationException.When(string.IsNullOrEmpty(password), "A senha deve ser informada");

            Email = email;
            Password = password;

        }
    }
}
