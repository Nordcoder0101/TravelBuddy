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
    [Required]
    public DateTime TheDay {get;set;}
    public int TripId {get;set;}
    public List<Flight> Flights {get; set;}
    public List<RoadTrip> RoadTrips {get;set;}
    public List<ActivityAndDay> ActivityAndDays {get;set;}
    public Day(){}
    public Day(DateTime date, int tripid)
    {
      TheDay = date;
      TripId = tripid;
    }
  }
}