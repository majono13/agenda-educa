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

        #region Delete School
        //Método assíncrono para deletar escola
        public async Task<ResultService> DeleteSchoolAsync(int id)
        {
            var school = await _schoolRepository.GetSchoolByIdAsync(id);

            if(school == null)
                return ResultService.Fail("Não foram encontrados dados correspondentes a requisição");

            await _schoolRepository.DeleteSchoolAsync(_mapper.Map<School>(school));

            return ResultService.Ok($"A escola: {school.Name} foi excluída com sucesso!");
        }
        #endregion

        #region Edit School
        //Método assíncrono para editar escola
        public async Task<ResultService> EditSchoolAsync(SchoolDTO schoolDTO)
        {
            //Validação de parâmetro
            if(schoolDTO == null)
                return ResultService.Fail<SchoolDTO>("Objeto deve ser informado!");

            var result = new SchoolDtoValidator().Validate(schoolDTO);

            if (!result.IsValid)
                return ResultService.RequestError<SchoolDTO>("Erro ao validar objeto", result);

            //Busca aluno no servidor
            var school = await _schoolRepository.GetSchoolByIdAsync(schoolDTO.Id);
            if(school == null) 
                return ResultService.Fail<SchoolDTO>("Não foram encontrados dados correspondentes a requisição");

            //Mapeamento e edição de dados
            school = _mapper.Map<SchoolDTO, School>(schoolDTO, school);
            await _schoolRepository.EditSchoolAsync(school);

            return ResultService.Ok("Escola editada com sucesso!");
        }
        #endregion

        #region Get Schools
        //Método assíncrono para buscar escolas
        public async Task<ResultService<ICollection<SchoolDTO>>> GetSchoolsAsync(int teacherId)
        {
            var schools = await _schoolRepository.GetSchoolsAsync(teacherId);

            if (schools == null)
                return ResultService.Fail<ICollection<SchoolDTO>>
                    ("Não foram encontrados dados correspondentes a requisição");
            return ResultService.Ok(_mapper.Map<ICollection<SchoolDTO>>(schools));
        }
        #endregion
    }
}
