using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using TravelBuddy.Models;

namespace TravelBuddy.HelperModels
{
  public class TripDashboard
  {
    public List<Day> DaysInTrip {get;set;}
    public List<Flight> AllFlightsInDay {get;set;}
    public List<RoadTrip> AllRoadtripsInDay {get;set;}
    public TripDashboard(){}
    public TripDashboard(string DoW, List<Day> DiT, List<Flight> AFiD, List<RoadTrip> ARiD)
    {
      DaysInTrip = DiT;
      AllFlightsInDay = AFiD;
      AllRoadtripsInDay = ARiD;
    }

  }
}
