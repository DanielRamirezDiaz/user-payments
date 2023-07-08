using AutoMapper;
using BusinessLogic.VM;
using Domain.Models;

namespace BusinessLogic.AutoMapper
{
  public class UserBusinessProfile : Profile
  {
    public UserBusinessProfile()
    {
      CreateMap<UserBusiness, UserBusinessVm>();
    }
  }
}
