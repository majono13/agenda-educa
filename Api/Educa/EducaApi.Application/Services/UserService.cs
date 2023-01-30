using AutoMapper;
using EducaApi.Application.DTOs;
using EducaApi.Application.DTOs.Validations;
using EducaApi.Application.Services.Interfaces;
using EducaApi.Domain.Entities;
using EducaApi.Domain.Repositories;
using FluentValidation;

namespace EducaApi.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService()
        {}

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<UserDTO>> CreateUserAsync(UserDTO userDTO)
        {
            //Validação do parâmetro
            if (userDTO == null)
                return ResultService.Fail<UserDTO>("Objeto deve ser informado!");

            var result = new UserDtoValidator().Validate(userDTO);

            if (!result.IsValid)
                return ResultService.RequestError<UserDTO>("Erro ao validar objeto", result);

            //Mapeamento
            var user = _mapper.Map<User>(userDTO);

            //Criação do dado no bd e retorno do serviço
            var data = await _userRepository.CreateUserAsync(user);

            return ResultService.Ok<UserDTO>(_mapper.Map<UserDTO>(data));
        }

        public async Task<ResultService<TeacherDto>> LoginAsync(UserDTO userDTO)
        {
            if (userDTO == null)
                return ResultService.Fail<TeacherDto>("Objeto deve ser informado!");

            var user = _mapper.Map<User>(userDTO);
            var result = await _userRepository.LoginAsync(user);

            if (result == null)
                return ResultService.Fail<TeacherDto>("E-mail ou senha inválidos!");

            return ResultService.Ok<TeacherDto>(_mapper.Map<TeacherDto>(result));

        }
    }
}
