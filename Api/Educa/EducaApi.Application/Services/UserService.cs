using AutoMapper;
using EducaApi.Application.DTOs;
using EducaApi.Application.DTOs.Validations;
using EducaApi.Application.Services.Interfaces;
using EducaApi.Domain.Authentication;
using EducaApi.Domain.Entities;
using EducaApi.Domain.Repositories;
using Microsoft.AspNetCore.Identity;

namespace EducaApi.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ITokenGenerator _tokenGenerator;

        public UserService(IUserRepository userRepository,
            IMapper mapper,
            ITokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenGenerator = tokenGenerator;
        }

        #region Create user
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
            HashPassword(userDTO);
            var user = _mapper.Map<User>(userDTO);


            //Criação do dado no bd e retorno do serviço
            var data = await _userRepository.CreateUserAsync(user);

            return ResultService.Ok<UserDTO>(_mapper.Map<UserDTO>(data));
        }
        #endregion

        #region Login
        /** Método assíncrono para logar usuário **/
        public async Task<ResultService<UserDTO>> LoginAsync(UserDTO userDTO)
        {
            if (userDTO == null)
                return ResultService.Fail<UserDTO>("Objeto deve ser informado!");

            //Verifica se existe usuário com email enviado
            var userDb = await _userRepository.GetUserByEmailAsync(userDTO.Email);

            if (userDb == null)
                return ResultService.Fail<UserDTO>("Usuário não encontrado");

            //var user = _mapper.Map<User>(userDTO);

            //Faz hash para validar a senha enviada
            if (await VerifyPassword(userDTO, userDb))
            {
                var res = _mapper.Map<UserDTO>(userDb);
                res.Token = _tokenGenerator.Generator(userDb);

                return ResultService.Ok(res);
            }

            return ResultService.Fail<UserDTO>("E-mail ou senha inválidos");

        }
        #endregion

        #region Update password
        /** Método assíncrono para atualizar senha **/
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
            HashPassword(userDTO);
            //mapeamento para edição de dados
            var map = _mapper.Map<UserDTO, User>(userDTO, user);


            await _userRepository.UpdateUserAsync(_mapper.Map<User>(map));
            return ResultService.Ok("Usuário Editado com sucesso!");
        }
        #endregion

        #region Get user by email
        /** Método Assíncrono para buscar usuário por e-mail **/
        public async Task<ResultService<UserDTO>> GetUserByEmailAsync(string email)
        {
            var result = await _userRepository.GetUserByEmailAsync(email);

            if (result == null)
                return ResultService.Fail<UserDTO>("Usuário não encontrado");

            return ResultService.Ok<UserDTO>(_mapper.Map<UserDTO>(result));
        }
        #endregion

        #region Get user email by token

        /** Método assíncrono para recuperar usuário através do token **/
        public async Task<ResultService<string>> GetUserEmailByToken(string token)
        {
            if (token == null)
                return ResultService.Fail<string>("O token deve ser informado!");

            var result = await _userRepository.GetUserEmailByToken(token);

            if (result == null)
                return ResultService.Fail<string>("Usuário não encontrado");

            return ResultService.Ok<string>(result);
        }

        #endregion

        #region Private methods
        //Método privado para realizar hash da senha enviada pelo front
        private static void HashPassword(UserDTO user)
        {
            var passwordHash = new PasswordHasher<UserDTO>();
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
        #endregion
    }
}
