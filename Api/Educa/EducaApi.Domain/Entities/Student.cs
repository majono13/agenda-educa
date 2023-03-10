using EducaApi.Domain.Validations;

namespace EducaApi.Domain.Entities
{
    public class Student
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Class { get; private set; }       
        public string Observations { get; private set; }
        public int TeacherId { get; private set; }
        public virtual Teacher Teacher { get;private set; }
        public virtual School School { get; private set; }
        public int SchoolId { get; private set; }


        public Student()
        {}

        public Student(string name, string @class, string? observations)
        {
            Validation(name, @class);
            Observations = observations;
        }

        public Student(int id, string name, string @class, string? observations)
        {

            DomainValidationException.When(id < 0, "Informe o ID");
            Id = id;

            Validation(name, @class);
            Observations = observations;
        }

        private void Validation(string name, string @class)
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

            Name = name;
            Class = @class;
        }
    }
}
