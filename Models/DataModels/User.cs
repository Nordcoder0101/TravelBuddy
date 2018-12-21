using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace TravelBuddy.Models
{
  public class User
  {
    [Key]
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    // --- navigation props --- //
    public List<Trip> AllTrips { get; set; }
  }
}