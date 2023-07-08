namespace Domain.Models
{
  public class User
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }

    public virtual ICollection<UserBusiness> UserBusinesses { get; set;}
  }
}
