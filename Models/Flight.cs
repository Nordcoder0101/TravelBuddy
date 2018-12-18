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
    [Required]
    public string Airline {get; set;}
    public string FlightNumber { get; set; }
    [Required]
    public DateTime Departure {get;set;}
    [Required]
    
    public DateTime Arrival {get;set;}
    [Required]
    public string DepartingCity {get;set;}
    [Required]
    public string ArrivalCity {get;set;}
    
    public int DayId {get;set;}
    public Flight(){}
    
  }
}
