using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace TravelBuddy.Models
{
  public class LoginUser
  {
    [EmailAddress]
    [Required]
    public string email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string password { get; set; }

    public LoginUser() { }
  }

}