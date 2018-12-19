using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TravelBuddy.Models;
using TravelBuddy.HelperModels;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Data.Entity;

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
      .Include(d => d.Flights)
      .Include(d => d.RoadTrips)
      .ToList();



      return View();
    }

    [HttpGet("getcitystate/{id}")]
    public IActionResult GetCityState(int id)
    {
      List<Day> AllDaysInTrip = dbContext.Days
      .Where(d => d.TripId == id)
      .Include(d => d.Flights)
      .Include(d => d.RoadTrips)
      .ToList();

     var Response = new {
        AllDaysInTrip = AllDaysInTrip,
        test = "hello"
      };

      return Json(Response);
    }
  }
}
