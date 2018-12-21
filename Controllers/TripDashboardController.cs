using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TravelBuddy.Models;
using TravelBuddy.HelperModels;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Data.Entity;
using Newtonsoft.Json;

namespace TravelBuddy.Controllers
{
  public class TripDashboardController : Controller
  {
    private TravelBuddyContext dbContext;

    public TripDashboardController(TravelBuddyContext context)
    {
      dbContext = context;

    }
    [HttpGet("showdays/{id}")]
    public IActionResult TripDashboard(int id)
    {
    
      List<Day> AllDaysInTrip = dbContext.Days
      .Where(d => d.TripId == id)
      .ToList();



      return View("_ShowDays",AllDaysInTrip);
    }

    [HttpGet("getcitystate/{id}")]
    public IActionResult GetCityState(int id)
    {
      // List<Flight> test = dbContext.Flights.Include(f => f.Day).ToList();

      // List<Day> AllDaysInTrip = dbContext.Days
      // .Include(a => a.Flights)
      // .Where(t => t.TripId == id)
      // .ToList();

      List<Day> DaysWithFlight = dbContext.Days
      .Include(d => d.FlightsInDay).Where(d => d.TripId == id)
      .ToList();

      foreach(var d in DaysWithFlight)
        foreach(var f in d.FlightsInDay)
      {
        System.Console.WriteLine($"<><><><><{f.ArrivalCity}><><><><><><<");
      }
      
      List<Flight> AllFlights = dbContext.Flights
        .Include(f => f.Day)
        .Include(f => f.Day.Trip)
        .Include(f => f.Day.Trip.User)
        .Where(f => f.Day.Trip.TripId == id)
        .ToList(); 
      // // List<Flight> AllFlightsInTrip = new List<Flight>();

      // foreach (var f in AllFlights)
      // {
      //   System.Console.WriteLine($"(*)(*)(*)>>>>>>>>>>>>>{f.DayId}<<<<<<<<<<<<<<<<<<<)(*)(*)(*)(*)(*)(*)");
      // }

      // foreach (var f in AllDaysInTrip)
      // {
      //   System.Console.WriteLine($"(*)(*)(*)(*)(*)(*)(*)(*)(*)(*){f.DayId}(*)(*)(*)(*)(*)(*)(*)");
      // }


    // foreach(var d in AllDaysInTrip)
    // {
    //   foreach(var f in AllFlights)
    //   {
    //       if (d.DayId == f.DayId)
    //       {
    //         AllFlightsInTrip.Add(f);
    //       }
    //   }
      
    // }

      // var Response = new {
        // allDaysInTrip = AllDaysInTrip
      //  allFlightsInTrip = AllFlightsInTrip
    //  };

      // var Response = JsonConvert.SerializeObject(AllDaysInTrip, Formatting.Indented,
      //   new JsonSerializerSettings
      //   {
      //     ReferenceLoopHandling = ReferenceLoopHandling.Serialize
      //   });
     
     var Response = DaysWithFlight;
    // var Response = AllDaysInTrip;

      return Json(Response);
    }
  }
}
