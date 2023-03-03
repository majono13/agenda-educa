using EducaApi.Domain.Validations;

namespace EducaApi.Domain.Entities
{
    public class School
    {
        public int TeacherId { get; private set; }
        public int Id { get; private set; }
        public string Cep { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }

        public string Name { get; private set; }
        public virtual ICollection<Student> Students { get; private set; }
        public virtual Teacher Teacher { get; private set; }

        public School(string cep, string street, string number, string district, string city, string state, string name)
        {
            Students = new List<Student>();

            Validation(cep, street, number, district, city, state, name);
        }

        public School(int id, string cep, string street, string number, string district, string city, string state, string name)
        {
            DomainValidationException.When(id < 0, "Informe o ID");
            Id = id;

            Validation(cep, street, number, district, city, state, name);
            Students = new List<Student>();

        }

        private void Validation(string cep, string street, string number, string district, string city, string state, string name)
        {
            #region Name
            DomainValidationException.When(string.IsNullOrEmpty(name), "Informe o nome da escola!");
            DomainValidationException.When(name.Length < 2, "O nome deve ter no mínimo 3 caracteres");
            DomainValidationException.When(name.Length > 50, "O nome deve ter no máximo 50 caracteres");
            #endregion

            #region Address
            DomainValidationException.When(cep.Length != 9, "Cep inválido");
            DomainValidationException.When(string.IsNullOrEmpty(street), "Informe a Rua!");
            DomainValidationException.When(string.IsNullOrEmpty(district), "Informe o bairro!");
            DomainValidationException.When(string.IsNullOrEmpty(city), "Informe a cidade!");
            DomainValidationException.When(string.IsNullOrEmpty(state), "Informe o estado!");
            #endregion

            Cep = cep;
            Street = street;
            Number = number;
            District = district;
            City = city;
            State = state;
            Name = name;
        }
    }
}
