using EducaApi.Application.Services;
using EducaApi.Domain.Entities;
using System.Text.Json.Serialization;

namespace EducaApi.Application.DTOs
{
    public class SchoolDTO
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Cep { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }


    }
}
