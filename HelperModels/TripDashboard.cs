using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using TravelBuddy.Models;

namespace TravelBuddy.HelperModels
{
  public class TripDashboard
  {
    public int? LoggedInUserId { get; set; }
    public string UserName {get;set;}    
    public List<Trip> AllTrips {get;set;}
    public Trip NewTrip {get;set;}

    public TripDashboard(int? id, string username, List<Trip> alltrips, Trip newtrip)
    {
      LoggedInUserId = id;
      UserName = username;
      AllTrips = alltrips;
      NewTrip = newtrip;
    }
  }
}
