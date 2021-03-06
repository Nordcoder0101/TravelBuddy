using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using TravelBuddy.Models;

namespace TravelBuddy.HelperModels
{
  public class UserDashboard
  {
    public int UserId { get; set; }
    public string UserName {get;set;}    
    public List<Trip> AllTrips {get;set;}
    
    public string TripName {get;set;}
    public DateTime StartDate {get;set;}
    public DateTime EndDate  {get;set;}
    

    public UserDashboard(){}
    public UserDashboard(int id, string username, List<Trip> alltrips)
    {
      UserId = id;
      UserName = username;
      AllTrips = alltrips;
      
    }
  }
}
