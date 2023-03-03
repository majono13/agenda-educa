using AutoMapper;
using EducaApi.Application.DTOs;
using EducaApi.Application.DTOs.Validations;
using EducaApi.Application.Services.Interfaces;
using EducaApi.Domain.Entities;
using EducaApi.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducaApi.Application.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IMapper _mapper;

        public SchoolService(ISchoolRepository schoolRepository, IMapper mapper)
        {
            _schoolRepository = schoolRepository;
            _mapper = mapper;
        }



        #region Create School
        //Método assíncrono para criar nova escola
        public async Task<ResultService<SchoolDTO>> CreateSchoolAsync(SchoolDTO schoolDto)
        {

            //Validação do parÂmetro
            if (schoolDto == null)
                return ResultService.Fail<SchoolDTO>("Objeto deve ser informado!");

            var result = new SchoolDtoValidator().Validate(schoolDto);

            if(!result.IsValid)
                return ResultService.RequestError<SchoolDTO>("Erro ao validar objeto", result);

            //Mapeamento de entidade
            var school = _mapper.Map<School>(schoolDto);

            //Criação do dado no bd e retorno do serviço
            var data = await _schoolRepository.CreateSchoolAsync(school);

           return ResultService.Ok<SchoolDTO>(_mapper.Map<SchoolDTO>(data));
        }
        #endregion
    }
}
