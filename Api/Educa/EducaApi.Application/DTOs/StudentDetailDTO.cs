using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducaApi.Application.DTOs
{
    public class StudentDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string School { get; set; }
        public string Class { get; set; }
        public int TeacherId { get; set; }
        public int SchoolId { get; set; }
    }
}
