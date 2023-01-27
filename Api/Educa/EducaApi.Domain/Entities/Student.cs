using EducaApi.Domain.Validations;

namespace EducaApi.Domain.Entities
{
    public class Student
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string School { get; private set; }
        public string Class { get; private set; }       
        public int TeacherId { get; private set; }
        public virtual Teacher Teacher { get; set; }

        public Student()
        {}

        public Student(string name, string school, string @class)
        {
            Validation(name, school, @class);
        }

        public Student(int id, string name, string school, string @class)
        {

            DomainValidationException.When(id < 0, "Informe o ID");
            Id = id;

            Validation(name, school, @class);
        }

        private void Validation(string name, string school, string @class)
        {
            #region Name
            DomainValidationException.When(string.IsNullOrEmpty(name), "Informe o nome do aluno");
            DomainValidationException.When(name.Length < 2, "O nome deve ter no mínimo 3 caracteres");
            DomainValidationException.When(name.Length > 50, "O nome deve ter no máximo 50 caracteres");
            #endregion

            #region School
            DomainValidationException.When(string.IsNullOrEmpty(school), "Informe a escola do aluno");
            DomainValidationException.When(school.Length < 2, "O nome da escola deve ter no mínimo 3 caracteres");
            DomainValidationException.When(school.Length > 50, "O nome da escola deve ter no máximo 50 caracteres");
            #endregion

            #region Class
            DomainValidationException.When(string.IsNullOrEmpty(@class), "Informe a classse do aluno");
            DomainValidationException.When(school.Length > 15, "A classe deve ter no máximo 15 caracteres");
            #endregion

            Name = name;
            School = school;
            Class = @class;
        }
    }
}
