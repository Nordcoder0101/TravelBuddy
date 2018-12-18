using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace TravelBuddy.Models
{
  public class ActivityAndDay
  {
    [Key]
    public int ActivityAndDayId { get; set; }
    public int UserId { get; set; }
    public int ActivityId { get; set; }
    public Day Day { get; set; }
    public Activity Activity { get; set; }
    public ActivityAndDay(){}


  }
}