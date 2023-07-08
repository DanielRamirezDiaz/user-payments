using Arch.EntityFrameworkCore.UnitOfWork;
using Data.Context;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
  public class CustomUserRepository : Repository<User>, IRepository<User>, IUserRepository
  {
    public CustomUserRepository(UserPaymentsDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<User> GetUser(string email)
    {
      return await _dbContext.Set<User>().FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<ICollection<UserBusiness>> GetUserPayments(int userId)
    {
      return await _dbContext.Set<User>()
        .Include(x => x.UserBusinesses)
          .ThenInclude(x => x.Payments)
        .Where(x => x.Id == userId)
        .Select(x => x.UserBusinesses)
        .FirstOrDefaultAsync();
    }

    public async Task AddPayment(Payment payment)
    {
      _dbContext.AddAsync(payment);
      await _dbContext.SaveChangesAsync();
    }

    public Task<bool> ServiceLastPaidToday(int serviceId)
    {
      var today = DateTime.Today;
      return _dbContext.Set<UserBusiness>()
        .AnyAsync(x => x.Id == serviceId && x.Payments.Any(p => EF.Functions.DateDiffDay(p.Date, today) == 0));
    }

    public async Task<bool> PaymentExists(int paymentId)
    {
      return await _dbContext.Set<Payment>().AnyAsync(x => x.Id == paymentId);
    }

    public async Task RemovePayment(int paymentId)
    {
      var payment = await _dbContext.Set<Payment>().FirstOrDefaultAsync(x => x.Id == paymentId);
      _dbContext.Remove(payment);
      await _dbContext.SaveChangesAsync();
    }
  }
}
