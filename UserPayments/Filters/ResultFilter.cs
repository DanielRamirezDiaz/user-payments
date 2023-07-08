using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using UserPayments.Filters.Models;

namespace UserPayments.Filters
{
  public class ResultFilter : IAsyncResultFilter
  {
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
      if (context.Result is OkObjectResult okObjectResult)
      {
        var result = okObjectResult.Value;

        if (!IsResponseBase(result))
        {
          var responseBase = new ResponseBase<object?>
          {
            Result = result,
            Type = ResponseType.Success
          };

          context.Result = new OkObjectResult(responseBase);
        }
      }

      await next();
    }

    private static bool IsResponseBase(object? response)
    {
      var isResponseBase =
        response != null
        && response.GetType().IsGenericType
        && response.GetType().GetGenericTypeDefinition() == typeof(ResponseBase<>);

      return isResponseBase;
    }
  }
}
