using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace TravelBuddy.Models
{
  public class FlightValidation

  {

    [Required]
    public string Airline {get; set;}
    [Required]
    public string FlightNumber { get; set; }
    [Required]
    public DateTime Departure {get;set;}
    [Required]
    public DateTime Arrival {get;set;}
    [Required]
    public string DepartingCity {get;set;}
    [Required]
    public string DepartingState { get; set; }
    [Required]
    public string ArrivalCity {get;set;}
    [Required]
    public string ArrivalState { get; set; }
    [Required]
    public int DayId {get;set;}
  }
}
