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

       /** Método assíncrono para criar novo professor **/
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

        /** Método assíncrono para deletar professor salvo no banco de dados **/
        public async Task<ResultService> DeleteTeacherAsync(int id)
        {
            var teacher = await _teacherRepository.GetTeacherByIdAsync(id);

            if (teacher == null)
                return ResultService.Fail("Não foram encontrados dados correspondentes a requisição");

            await _teacherRepository.DeleteTeacherAsync(teacher);

            return ResultService.Ok("Dado removido do banco de dados");
        }

        /** Método assíncrono para buscar professor por id **/
        public async Task<ResultService<TeacherDto>> GetTeacherByIdAsync(int id)
        {
            var result = await _teacherRepository.GetTeacherByIdAsync(id);
            if (result == null)
                return ResultService.Fail<TeacherDto>("Não foram encontrados dados correspondentes a requisição");
            return ResultService.Ok(_mapper.Map<TeacherDto>(result));
        }

        /** Método assíncrono para editar professor **/
        public async Task<ResultService> UpdateTeacherAsync(TeacherDto teacherDto)
        {
            //Verifica se o parâmetro é válido antes de autualizar
            if (teacherDto == null)
                return ResultService.Fail("O objeto deve ser informado");

            var validation = new TeacherDtoValidator().Validate(teacherDto);

            if (!validation.IsValid)
                return ResultService.RequestError("Erro ao validar dados", validation);

            //Busca e atualiza dados
            var teacher = await _teacherRepository.GetTeacherByIdAsync(teacherDto.Id);

            if (teacher == null)
                return ResultService.Fail<TeacherDto>("Não foram encontrados dados correspondentes a requisição");

            //mapeamento para edição de dados
            teacher = _mapper.Map<TeacherDto, Teacher>(teacherDto, teacher);

            await _teacherRepository.EditTeacherAsync(teacher);
            return ResultService.Ok("Editado com sucesso!");
        }
    }
}
