﻿namespace EducaApi.Application.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Observations { get; set; }
        public DateTime? Birthday { get; set; }
        public string? ParentsContact { get; set; }
        public string Class { get; set; }
        public int TeacherId { get; set; }
        public int SchoolId { get; set; }
    }
}
