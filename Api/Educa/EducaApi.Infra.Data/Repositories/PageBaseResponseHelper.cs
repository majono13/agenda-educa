using EducaApi.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EducaApi.Infra.Data.Repositories
{
    public static class PageBaseResponseHelper
    {
        public static async Task<TResponse> GetResponseAsync<TResponse, T>(IQueryable<T> query, PageBaseRequest request)
            where TResponse : PageBaseResponse<T>, new()
        {
            var response = new TResponse();
            var count = await query.CountAsync();
            response.TotalPages = (int)Math.Ceiling((double)count / request.PageSize);
            response.TotalRegisters = count;

            if (string.IsNullOrEmpty(request.OrderByPropety))
                response.Data = await query.ToListAsync();

            else
                //Paginação do bd
                response.Data = query
                    //Ordena os dados
                    .OrderByDynamic(request.OrderByPropety)
                    //Quantidade de linhas (dados) que serão pulados
                    .Skip((request.Page - 1) * request.PageSize)
                    //Quantidade de linhas (dados) que serão enviados como resposta
                    .Take(request.PageSize)
                    .ToList();

            return response;
        }

        private static IEnumerable<T> OrderByDynamic<T>(this IEnumerable<T> query, string propertyName)
        {
            return query.OrderBy(x => x
                .GetType()
                .GetProperty(propertyName)
                .GetValue(x, null));
        }
    }
}
