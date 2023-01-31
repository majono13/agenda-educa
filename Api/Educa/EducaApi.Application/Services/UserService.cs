using AutoMapper;
using EducaApi.Application.DTOs;
using EducaApi.Application.DTOs.Validations;
using EducaApi.Application.Services.Interfaces;
using EducaApi.Domain.Entities;
using EducaApi.Domain.Repositories;
using Microsoft.AspNetCore.Identity;

namespace EducaApi.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /** Método assíncrono para criar novo usuário **/
        public async Task<ResultService<UserDTO>> CreateUserAsync(UserDTO userDTO)
        {
            //Validação do parâmetro
            if (userDTO == null)
                return ResultService.Fail<UserDTO>("Objeto deve ser informado!");

            var result = new UserDtoValidator().Validate(userDTO);
            if (!result.IsValid)
                return ResultService.RequestError<UserDTO>("Erro ao validar objeto", result);

            //Realiza hash na senha
            var user = _mapper.Map<User>(userDTO);
            HashPassword(user);

            //Criação do dado no bd e retorno do serviço
            var data = await _userRepository.CreateUserAsync(user);

            return ResultService.Ok<UserDTO>(_mapper.Map<UserDTO>(data));
        }

        /** Método assíncrono para logar usuário **/
        public async Task<ResultService<TeacherDto>> LoginAsync(UserDTO userDTO)
        {
            if (userDTO == null)
                return ResultService.Fail<TeacherDto>("Objeto deve ser informado!");

            //Verifica se existe usuário com email enviado
            var userDb = await _userRepository.GetUserByEmailAsync(userDTO.Email);

            if (userDb == null)
                return ResultService.Fail<TeacherDto>("Usuário não encontrado");

            //var user = _mapper.Map<User>(userDTO);

            //Faz hash para validar a senha enviada
            //Se a senha bater, devolve a entidade teacher
            if (await VerifyPassword(userDTO, userDb))
                return ResultService.Ok(_mapper.Map<TeacherDto>(userDb.Teacher));

            return ResultService.Fail<TeacherDto>("E-mail ou senha inválidos");

        }

        /** Método assíncrono para login **/
        public async Task<ResultService> UpdateUserAsync(UserDTO userDTO)
        {
            #region validações
            //Verifica se o parâmetro é válido antes de autualizar
            if (userDTO == null)
                return ResultService.Fail("O objeto deve ser informado");

            var validation = new UserDtoValidator().Validate(userDTO);

            if (!validation.IsValid)
                return ResultService.RequestError("Erro ao validar dados", validation);

            //Verifica se existe usuário com email enviado
            var user = await _userRepository.GetUserByEmailAsync(userDTO.Email);
            if (user == null)
                return ResultService.Fail("Usuário não encontrado!");

            //Verifica se a nova senha é igual a anterior
            if (await VerifyPassword(userDTO, user))
                return ResultService.Fail("A nova senha não pode ser igual a anterior");

            #endregion


            //Realiza hash na nova senha e salva no banco de dados
            user.Password = userDTO.Password;
            HashPassword(user);

            await _userRepository.UpdateUserAsync(_mapper.Map<User>(user));
            return ResultService.Ok("Usuário Editado com sucesso!");
        }

        //Método privado para realizar hash da senha enviada pelo front
        private static void HashPassword(User user)
        {
            var passwordHash = new PasswordHasher<User>();
            user.Password = passwordHash.HashPassword(user, user.Password);
        }

        //Método privado para verificar senha
        private async Task<bool> VerifyPassword(UserDTO user, User userDb)
        {
            var passwordHash = new PasswordHasher<UserDTO>();
            var status = passwordHash.VerifyHashedPassword(user, userDb.Password, user.Password);

            switch (status)
            {
                case PasswordVerificationResult.Success:
                    return true;
                case PasswordVerificationResult.Failed:
                    return false;
                default:
                    throw new InvalidOperationException();
            }
        }

    }
}
