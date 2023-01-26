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
            DomainValidationException.When(string.IsNullOrEmpty(name), "Informe o nome do aluno");
            DomainValidationException.When(string.IsNullOrEmpty(school), "Informe a escola do aluno");
            DomainValidationException.When(string.IsNullOrEmpty(@class), "Informe a classse do aluno");

            Name = name;
            School = school;
            Class = @class;
        }
    }
}
