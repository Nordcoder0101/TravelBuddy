using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace TravelBuddy.Models
{
  public class TripValidation
  {
    [Required]
    public int UserId {get;set;}
    [Required]
    public string TripName{get;set;}
    [Required]
    public DateTime StartDate {get;set;}
    [Required]
    public DateTime EndDate {get;set;}
  }
}