using System.Collections.Generic;

namespace UserPayments.Filters.Models
{
  public class ResponseBase<T>
  {
    public ResponseType Type { get; set; }
    public List<string> Messages { get; set; } = new List<string>();
    public T? Result { get; set; }
  }

  public enum ResponseType
  {
    Info = 1,
    Error = 2,
    Success = 3,
    Warning = 4,
  }
}
