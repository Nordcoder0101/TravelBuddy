using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace TravelBuddy.Models
{
  public class Activity
  {
    [Key]
    public int ActivityId { get; set; }
    [Required]
    [MinLength(2)]
    public string Title { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    [MinLength(10)]
    public string Description { get; set; }
    public int CreatorId { get; set; }
    public string CreatorName { get; set; }  
    public List<ActivityAndDay> ActivityAndDays { get; set; }

  }
}