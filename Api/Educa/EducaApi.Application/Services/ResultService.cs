using FluentValidation.Results;

namespace EducaApi.Application.Services
{

    //Classe genérica para retorno de resposta ao front
    public class ResultService
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public ICollection<ErrorValidation> Erros { get; set; }

        #region Request Error
        public static ResultService RequestError(string message, ValidationResult validationResult)
        {
            return new ResultService
            {
                IsSuccess = false,
                Message = message,
                Erros = validationResult.Errors.Select(x => 
                new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage }).ToList()

            };
        }

        public static ResultService<T> RequestError<T>(string message, ValidationResult validationResult)
        {
            return new ResultService<T>
            {
                IsSuccess = false,
                Message = message,
                Erros = validationResult.Errors.Select(x =>
                new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage }).ToList()

            };
        }
        #endregion

        #region Request Fail
        public static ResultService Fail(string message) => 
            new ResultService { IsSuccess = false, Message = message };

        public static ResultService<T> Fail<T>(string message) => 
            new ResultService<T> { IsSuccess = false, Message = message };
        #endregion

        #region Request Success
        public static ResultService Ok(string message) => 
            new ResultService { IsSuccess = true, Message = message };
        public static ResultService<T> Ok<T>(T data) =>
         new ResultService<T> { IsSuccess = true, Data = data };
        #endregion
    }

    public class ResultService<T> : ResultService
    {
        public T Data { get; set; }
    }
}
