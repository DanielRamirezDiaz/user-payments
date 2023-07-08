using BusinessLogic.VM;
using Domain.Models;

namespace BusinessLogic.Interfaces
{
  public interface IUserService
  {
    Task<User> Login(string email);
    Task<ICollection<UserBusinessVm>> GetUserPayments(int userId);
    Task AddPayment(int serviceId, double ammount);
    Task RemovePayment(int paymentId);
    Task RemovePayments(int[] paymentIds);
  }
}
