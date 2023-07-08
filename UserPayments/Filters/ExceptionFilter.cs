using BusinessLogic.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using UserPayments.Filters.Models;

namespace UserPayments.Filters
{
  public class ExceptionFilter : IAsyncExceptionFilter
  {

    public async Task OnExceptionAsync(ExceptionContext context)
    {
      // TODO: Log exceptions
      var errorResponse = new ResponseBase<bool>();

      if (context.Exception is BusinessLogicException businessLogicException)
      {
        errorResponse.Messages.AddRange(businessLogicException.Messages);
        errorResponse.Type = ResponseType.Warning;
      }
      else
      {
        errorResponse.Messages.Add(context.Exception.Message);
        errorResponse.Type = ResponseType.Error;
      }

      context.Result = new OkObjectResult(errorResponse);
    }
  }
}
