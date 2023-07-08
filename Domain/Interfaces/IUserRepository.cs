using Domain.Models;

namespace Domain.Interfaces
{
  public interface IUserRepository
  {
    Task AddPayment(Payment payment);
    Task<User> GetUser(string email);
    Task<ICollection<UserBusiness>> GetUserPayments(int userId);
    Task<bool> ServiceLastPaidToday(int serviceId);
    Task<bool> PaymentExists(int paymentId);
    Task RemovePayment(int paymentId);
  }
}
