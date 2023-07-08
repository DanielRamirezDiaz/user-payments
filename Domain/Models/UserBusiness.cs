﻿namespace Domain.Models
{
  public class UserBusiness
  {
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public virtual User User { get; set; }
    public virtual ICollection<Payment> Payments { get; set; }
  }
}
