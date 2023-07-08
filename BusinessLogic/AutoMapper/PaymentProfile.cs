using AutoMapper;
using BusinessLogic.VM;
using Domain.Models;

namespace BusinessLogic.AutoMapper
{
  public class PaymentProfile : Profile
  {
    public PaymentProfile()
    {
      CreateMap<Payment, PaymentVm>();
    }
  }
}
