using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace TravelBuddy.Models
{
  public class Day
  {
    [Key]
    public int DayId { get; set;}
    public DateTime TheDay {get;set;}
    public string DayOfTheWeek {get;set;}
    public int TripId {get;set;}

    // --- navigation props --- //
    public Trip Trip { get; set;}
    public List<Flight> FlightsInDay {get; set;}
    // public List<RoadTrip> RoadTrips {get;set;}
    public List<ActivityAndDay> ActivityAndDays {get;set;}
  }
}