namespace BusinessLogic.VM
{
  public class UserBusinessVm
  {
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public virtual ICollection<PaymentVm> Payments { get; set; }
  }
}
