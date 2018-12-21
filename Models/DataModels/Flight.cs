using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace TravelBuddy.Models
{
  public class Flight
  {
    [Key]
    public int FlightId { get; set; }
    public string Airline {get; set;}
    public string FlightNumber { get; set; }
    public DateTime Departure {get;set;}
    public DateTime Arrival {get;set;}
    public string DepartingCity {get;set;}
    public string DepartingState { get; set; }
    public string ArrivalCity {get;set;}
    public string ArrivalState { get; set; }
    [ForeignKey("Day")]
    public int DayId {get;set;}

    // --- nav properties --- //
    public Day Day {get;set;}
    
    
    
    // public Flight(){}
    
  }
}
