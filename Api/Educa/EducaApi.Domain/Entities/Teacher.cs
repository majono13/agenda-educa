using EducaApi.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducaApi.Domain.Entities
{
    public class Teacher
    {
        public int Id { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public virtual ICollection<Student> Students { get; private set; }
        public virtual User User { get; private set; }

        public Teacher()
        {}

        public Teacher(string firstname, string lastname, string phone)
        {
            Validation(firstname, lastname, phone);
            Students = new List<Student>();
        }

        public Teacher(int id, string firstname, string lastname, string phone)
        {
            DomainValidationException.When(id < 0, "Informe o ID");
            Id = id;

            Validation(firstname, lastname, phone);
            Students = new List<Student>();
        }

        private void Validation(string firstname, string lastname, string phone)
        {
            #region Nome
            DomainValidationException.When(string.IsNullOrEmpty(firstname), "Informe o nome");
            DomainValidationException.When(firstname.Length < 2, "O nome deve ter no mínimo 3 caracteres");
            DomainValidationException.When(firstname.Length > 20, "O nome deve ter no máximo 20 caracteres");
            #endregion

            #region Sobrenome
            DomainValidationException.When(string.IsNullOrEmpty(lastname), "Informe o sobrenome");
            DomainValidationException.When(lastname.Length < 1, "O sobrenome deve ter no mínimo 2 caracteres");
            DomainValidationException.When(lastname.Length > 50, "O sobrenome deve ter no máximo 50 caracteres");
            #endregion

            #region Telefone
            DomainValidationException.When(string.IsNullOrEmpty(phone), "Informe o telefone");
            DomainValidationException.When(phone.Length != 11, "Telefone inválido");
            #endregion


            Firstname = firstname;
            Lastname = lastname;
            Phone = phone;

        }
    }
}
