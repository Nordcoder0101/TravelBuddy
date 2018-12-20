using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace TravelBuddy.Models
{
  public class UserValidation
  {
    [Required]
    [MinLength(3)]
    [Display(Name="First Name")]
    public string FirstName { get; set; }
    
    [Required]
    [MinLength(3)]
    [Display(Name="Last Name")]
    public string LastName { get; set; }

    [EmailAddress]
    [Required]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string Password { get; set; }

    [Compare("Password")]
    [DataType(DataType.Password)]
    public string Confirm { get; set; }

  }


}