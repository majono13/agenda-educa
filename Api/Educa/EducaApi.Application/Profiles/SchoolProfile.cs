using AutoMapper;
using EducaApi.Application.DTOs;
using EducaApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducaApi.Application.Profiles
{
    public class SchoolProfile : Profile
    {
        public SchoolProfile()
        {
            CreateMap<School, SchoolDTO>();
            CreateMap<SchoolDTO, School>(); 
        }
    }
}
