using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace TravelBuddy.Models
{
  public class Day
  {
    [Key]
    public int day_id { get; set;}
    public DateTime date {get;set;}
    public int trip_id {get;set;}

    // --- navigation props --- //
    public Trip Trip { get; set;}
    public List<Flight> FlightsInDay {get; set;}
  }
}