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
    public string DayOfTheWeek {get;set;}
    public int TripId {get;set;}
    [NotMapped]
    public List<string> Cities {get;set;}
    [NotMapped]
    public List<string> States {get;set;}
    public List<Flight> Flights {get; set;}
    public List<RoadTrip> RoadTrips {get;set;}
    public List<ActivityAndDay> ActivityAndDays {get;set;}
    public Day(){}
    public Day(DateTime date, string DoW, int tripid)
    {
      TheDay = date;
      DayOfTheWeek = DoW;
      TripId = tripid;
    }
  }
}