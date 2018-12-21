using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TravelBuddy.Models;
using TravelBuddy.HelperModels;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

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
    
      List<Day> AllDaysInTrip = dbContext.days
      .Where(d => d.trip_id == id)
      .ToList();

      return View("_ShowDays",AllDaysInTrip);
    }

    [HttpGet("getcitystate/{id}")]
    public JsonResult GetCityState(int id)
    {
      // List<Flight> AllFlights = dbContext.flights.ToList(); 
      List<Day> AllDays = dbContext.days
        .Include(d => d.FlightsInDay)
        .ToList();

      var Response = AllDays;

      System.Console.WriteLine("================");
      foreach(Day day in AllDays)
      {
        System.Console.WriteLine(day.date);
        System.Console.WriteLine(day.FlightsInDay);
        foreach(Flight flight in day.FlightsInDay)
        {
          System.Console.WriteLine(flight.airline_name);
        }
      }
      System.Console.WriteLine("================");
      System.Console.WriteLine(Response);

      return Json(Response);
    }
  }
}
