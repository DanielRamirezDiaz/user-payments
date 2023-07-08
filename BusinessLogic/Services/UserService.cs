using AutoMapper;
using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using BusinessLogic.VM;
using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
  public class UserService : IUserService
  {
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IMapper mapper, IUserRepository userRepository)
    {
      _mapper = mapper;
      _userRepository = userRepository;
    }

    public async Task<User> Login(string email)
    {
      var user = await _userRepository.GetUser(email);

      if (user == null)
      {
        throw new BusinessLogicException("User doesn't exist");
      }

      return user;
    }

    public async Task<ICollection<UserBusinessVm>> GetUserPayments(int userId)
    {
      var payments = await _userRepository.GetUserPayments(userId);

      return payments?
        .Select(x => _mapper.Map<UserBusinessVm>(x))
        .ToList();
    }

    public async Task AddPayment(int serviceId, double ammount)
    {
      await ValidateAddPayment(serviceId, ammount);

      var payment = new Payment
      {
        Ammount = ammount,
        UserBusinessId = serviceId,
      };

      await _userRepository.AddPayment(payment);
    }

    private async Task ValidateAddPayment(int serviceId, double ammount)
    {
      var errors = new List<string>();

      if (serviceId == 0)
      {
        errors.Add("No Service Selected");
      }

      if (ammount <= 0)
      {
        errors.Add("The ammount it's not valid");
      }

      var serviceLastPaidToday = await _userRepository.ServiceLastPaidToday(serviceId);

      if (serviceLastPaidToday)
      {
        errors.Add("This Service was already paid today");
      }

      if (errors.Any())
      {
        throw new BusinessLogicException(errors);
      }
    }

    public async Task RemovePayment(int paymentId)
    {
      if (!await _userRepository.PaymentExists(paymentId))
      {
        throw new BusinessLogicException("The payment was not found");
      }

      await _userRepository.RemovePayment(paymentId);
    }

    public async Task RemovePayments(int[] paymentIds)
    {
      var paymentsNotFound = 0;
      foreach (var paymentId in paymentIds)
      {
        if (!await _userRepository.PaymentExists(paymentId))
        {
          paymentsNotFound++;
        }
        else
        {
          await _userRepository.RemovePayment(paymentId);
        }
      }

      if (paymentsNotFound > 0)
      {
        throw new BusinessLogicException("At least one payment was not found");
      }
    }
  }
}
