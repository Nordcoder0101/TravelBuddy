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
    [Required]
    public DateTime StartDate {get;set;}
    [Required]
    public DateTime EndDate {get;set;}
    public List<RoadTrip> RoadTripsForTrip {get;set;}
    public List<Flight> FlightsInTrip {get;set;}
    public List<Day> DaysInTrip {get;set;}
    public Trip() {}
    public Trip(int userid, string tripname, DateTime startdate, DateTime enddate)
    {
      UserId = userid;
      TripName = tripname;
      StartDate = startdate;
      EndDate = enddate;
    }
  }
}