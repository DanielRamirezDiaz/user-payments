namespace BusinessLogic.Exceptions
{
  public class BusinessLogicException : Exception
  {
    public BusinessLogicException()
    {
      Messages = new List<string>();
    }

    public BusinessLogicException(string message) : this()
    {
      Messages.Add(message);
    }

    public BusinessLogicException(IEnumerable<string> messages) : this()
    {
      if (messages != null)
      {
        foreach (var message in messages)
        {
          Messages.Add(message);
        }
      }
    }

    public ICollection<string> Messages { get; set; }
  }
}
