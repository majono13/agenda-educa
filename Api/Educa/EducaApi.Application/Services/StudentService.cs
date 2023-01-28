using AutoMapper;
using EducaApi.Application.DTOs;
using EducaApi.Application.DTOs.Validations;
using EducaApi.Application.Services.Interfaces;
using EducaApi.Application.Validations;
using EducaApi.Domain.Entities;
using EducaApi.Domain.FiltersDb;
using EducaApi.Domain.Repositories;

namespace EducaApi.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRespository;
        private readonly IMapper _mapper;

        public StudentService()
        {}

        public StudentService(IStudentRepository studentRespository, IMapper mapper)
        {
            _studentRespository = studentRespository;
            _mapper = mapper;
        }

        public async Task<ResultService<StudentDTO>> CreateStudentAsync(StudentDTO studentDTO)
        {
            //Validação do parâmetro
            if (studentDTO == null)
                return ResultService.Fail<StudentDTO>("Objeto deve ser informado!");

            var result = new StudentDtoValidator().Validate(studentDTO);

            if (!result.IsValid)
                return ResultService.RequestError<StudentDTO>("Erro ao validar objeto", result);

            //Mapeamento
            var student = _mapper.Map<Student>(studentDTO);

            //Criação do dado no bd e retorno do serviço
            var data = await _studentRespository.CreateStudentAync(student);

            return ResultService.Ok<StudentDTO>(_mapper.Map<StudentDTO>(data));
        }

        public async Task<ResultService> DeleteStudentAsync(int id)
        {
            var student = await _studentRespository.GetStudentByIdAsync(id);

            if(student == null)
                return ResultService.Fail<StudentDTO>("Não foram encontrados dados correspondentes a requisição");

           await _studentRespository.DeleteStudentAsync(student);

            return ResultService.Ok($"Aluno/a: {student.Name} deletado com sucesso!");
        }

        public async Task<ResultService<PageBaseResponseDTO<StudentDTO>>> GetPagedAsync(StudentFilterDb studentFilterDb,int teacherId)
        {
            //Retorna dados paginados
            var studentPaged = await _studentRespository.GetPagedAsync(studentFilterDb, teacherId);
            //Mapeamento para o DTO
            var result = new PageBaseResponseDTO<StudentDTO>(
                    studentPaged.TotalRegisters, _mapper.Map<List<StudentDTO>>(studentPaged.Data));

            return ResultService.Ok(result);
        }

        public async Task<ResultService<StudentDTO>> GetStudentByIdAsync(int id)
        {
            var student = await _studentRespository.GetStudentByIdAsync(id);

            if(student == null)
                return ResultService.Fail<StudentDTO>("Não foram encontrados dados correspondentes a requisição");

            return ResultService.Ok<StudentDTO>(_mapper.Map<StudentDTO>(student));
        }

        public async Task<ResultService<ICollection<StudentDTO>>> GetStudentsAsync(int teacherId)
        {
            var students = await _studentRespository.GetStudentsAsync(teacherId);

            if(students == null)
                return ResultService.Fail<ICollection<StudentDTO>>
                    ("Não foram encontrados dados correspondentes a requisição");

            return ResultService.Ok(_mapper.Map<ICollection<StudentDTO>>(students));
        }

        public async Task<ResultService> UpdateStudentAsync(StudentDTO studentDTO)
        {
            //Validação do parâmetro
            if (studentDTO == null)
                return ResultService.Fail<StudentDTO>("Objeto deve ser informado");

            var validation = new StudentDtoValidator().Validate(studentDTO);

            if (!validation.IsValid)
                return ResultService.RequestError<StudentDTO>("Erro ao validar dados", validation);

            //Busca e atualiza dados
            var student = await _studentRespository.GetStudentByIdAsync(studentDTO.Id);

            if(student == null)
                return ResultService.Fail<ICollection<StudentDTO>>
                  ("Não foram encontrados dados correspondentes a requisição");

            //mapeamento para edição de dados
            student = _mapper.Map<StudentDTO, Student>(studentDTO, student);
            await _studentRespository.EditStudentAsync(student);
            return ResultService.Ok("Aluno editado com sucesso!");
        }
    }
}
