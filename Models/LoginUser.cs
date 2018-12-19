using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace TravelBuddy.Models
{
  public class LoginUser
  {
    [EmailAddress]
    [Required]
    [Display(Name="Email")]
    public string LoginEmail { get; set; }
    [Required]
    [Display(Name="Password")]
    [DataType(DataType.Password)]
    public string LoginPassword { get; set; }

    public LoginUser() { }
  }

}