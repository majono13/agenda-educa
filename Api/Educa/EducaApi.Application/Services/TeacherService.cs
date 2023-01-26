using AutoMapper;
using EducaApi.Application.DTOs;
using EducaApi.Application.Services.Interfaces;
using EducaApi.Application.Validations;
using EducaApi.Domain.Entities;
using EducaApi.Domain.Repositories;

namespace EducaApi.Application.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public TeacherService()
        {}

        public TeacherService(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<TeacherDto>> CreateTeacherAsync(TeacherDto teacherDto)
        {
            //Validação do parâmetro
            if (teacherDto == null)
                return ResultService.Fail<TeacherDto>("Objeto deve ser informado");

            var result = new TeacherDtoValidator().Validate(teacherDto);
            if (!result.IsValid)
                return ResultService.RequestError<TeacherDto>("Erro ao validar objeto", result);

            //Mapeamento
            var teacher = _mapper.Map<Teacher>(teacherDto);

            //Criação do dado no bd e retorno do serviço
            var data = await _teacherRepository.CreateTeacherAync(teacher);
            return ResultService.Ok<TeacherDto>(_mapper.Map<TeacherDto>(data));
        }
    }
}
