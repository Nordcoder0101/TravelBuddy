using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace TravelBuddy.Models
{
  public class Trip
  {
    [Key]
    public int trip_id { get; set; }
    public int user_id {get;set;}
    public string name {get;set;}
    public DateTime start_date {get;set;}
    public DateTime end_date {get;set;}

    // --- navigation props --- //
    public List<Day> Day { get; set; }
    public User User { get; set; }
  }
}