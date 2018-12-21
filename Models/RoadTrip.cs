using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace TravelBuddy.Models
{
  public class RoadTrip
  {
    [Key]
    public int DriveId { get; set; }
    [Required]
    public string DepartingCity {get;set;}
    public string DepartingState { get; set; }
    [Required]
    public string DestinationCity {get;set;}
    public string DestinationState {get;set;}
    public DateTime StartDateTime {get;set;}
    public int DayId {get;set;}
    public RoadTrip(){}
    
    
  }
}