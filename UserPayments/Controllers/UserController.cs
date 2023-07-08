using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace UserPayments.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
      _userService = userService;
    }

    [HttpGet("Login")]
    public async Task<IActionResult> Login([FromQuery] string email)
    {
      return Ok(await _userService.Login(email));
    }

    [HttpGet("GetUserPayments")]
    public async Task<IActionResult> GetUserPayments([FromQuery] int userId)
    {
      var result = await _userService.GetUserPayments(userId);
      return Ok(result);
    }

    [HttpGet("AddPayment")]
    public async Task<IActionResult> AddPayment([FromQuery] int serviceId, [FromQuery] double ammount)
    {
      await _userService.AddPayment(serviceId, ammount);
      return Ok();
    }

    [HttpGet("RemovePayment")]
    public async Task<IActionResult> RemovePayment([FromQuery] int paymentId)
    {
      await _userService.RemovePayment(paymentId);
      return Ok();
    }

    [HttpPost("RemovePayments")]
    public async Task<IActionResult> RemovePayments([FromBody] int[] paymentIds)
    {
      await _userService.RemovePayments(paymentIds);
      return Ok();
    }
  }
}
