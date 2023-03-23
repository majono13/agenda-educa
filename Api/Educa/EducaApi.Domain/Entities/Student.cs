using EducaApi.Domain.Validations;

namespace EducaApi.Domain.Entities
{
    public class Student
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Class { get; private set; }       
        public string? Observations { get; private set; }
        public DateTime? Birthday { get; private set; }
        public string?  ParentsContact { get; private set; }
        public int TeacherId { get; private set; }
        public virtual Teacher Teacher { get;private set; }
        public virtual School School { get; private set; }
        public int SchoolId { get; private set; }


        public Student()
        {}

        public Student(string name, string @class, string? observations, DateTime? birthday, string? parentsContact)
        {
            Validation(name, @class, observations, birthday, parentsContact);

        }

        public Student(int id, string name, string @class, string? observations, DateTime? birthday, string? parentsContact)
        {

            DomainValidationException.When(id < 0, "Informe o ID");
            Id = id;

            Validation(name, @class, observations, birthday, parentsContact);
        }

        private void Validation(string name, string @class, string? observations, DateTime? birthday, string? parentsContact)
        {
            #region Name
            DomainValidationException.When(string.IsNullOrEmpty(name), "Informe o nome do aluno");
            DomainValidationException.When(name.Length < 2, "O nome deve ter no mínimo 3 caracteres");
            DomainValidationException.When(name.Length > 50, "O nome deve ter no máximo 50 caracteres");
            #endregion

            #region Class
            DomainValidationException.When(string.IsNullOrEmpty(@class), "Informe a classse do aluno");
            DomainValidationException.When(@class.Length > 15, "A classe deve ter no máximo 15 caracteres");
            #endregion

            #region Observations
            DomainValidationException.When(observations?.Length > 1500, "Campo deve ter no máximo 1500 caracteres");
            #endregion

            #region ParentsContact
            DomainValidationException.When(parentsContact?.Length > 17, "Campo deve ter no máximo 17 caracteres");
            #endregion


            Name = name;
            Class = @class;
            Observations = observations;
            Birthday = birthday;
            ParentsContact = parentsContact;

        }
    }
}
