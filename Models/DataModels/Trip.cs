using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace TravelBuddy.Models
{
  public class Trip
  {
    [Key]
    public int TripId { get; set; }
    public int UserId {get;set;}
    public string TripName{get;set;}
    public DateTime StartDate {get;set;}
    public DateTime EndDate {get;set;}

    // --- navigation props --- //
    public List<Day> Day { get; set; }
    public User User { get; set; }
  }
}