namespace Domain.Models
{
  public class Payment
  {
    public int Id { get; set; }
    public int UserBusinessId { get; set; }
    public double Ammount { get; set; }
    public DateTime Date { get; set; }

    public virtual UserBusiness UserBusiness { get; set; }
  }
}
