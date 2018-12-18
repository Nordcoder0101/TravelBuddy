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
    public string StartingPoint {get;set;}
    [Required]
    public string Destination {get;set;}
    public DateTime StartDateTime {get;set;}
    public int DayId {get;set;}
    public RoadTrip(){}
    
    
  }
}