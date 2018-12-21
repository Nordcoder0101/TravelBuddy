using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace TravelBuddy.Models
{
  public class Flight
  {
    [Key]
    public int flight_id { get; set; }
    public int day_id {get;set;}
    public string airline_name {get; set;}
    public string flight_number { get; set; }
    public DateTime departure_date {get;set;}
    public DateTime arrival_date {get;set;}
    public string departing_city {get;set;}
    public string departing_state { get; set; }
    public string arrival_city {get;set;}
    public string arrival_state { get; set; }

    // --- nav properties --- //
    public Day Day {get;set;}
    
    
    
    // public Flight(){}
    
  }
}
