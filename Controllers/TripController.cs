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
  public class TripController : Controller
  {
    private TravelBuddyContext dbContext;

    public TripController(TravelBuddyContext context)
    {
      dbContext = context;

    }

    [HttpGet("tripdashboard")]
    public IActionResult TripDashboard(Trip NewTrip)
    {
      int? LoggedInUserId = HttpContext.Session.GetInt32("UserId");
      var LoggedInUser = dbContext.Users.FirstOrDefault(u => u.UserId == LoggedInUserId);
      List<Trip> AllTrips = dbContext.Trips.Where(t => t.UserId == LoggedInUserId).ToList();
      

      TripDashboard DashboardInfo = new TripDashboard(LoggedInUser.UserId, LoggedInUser.FirstName, AllTrips);

      return View(DashboardInfo);
    }

    [HttpGet("showcreatetrip")]
    public IActionResult ShowCreateTrip()
    {
      return PartialView("_ShowCreateTrip");
    }


    [HttpPost("createtrip")]
    public IActionResult CreateTrip(TripDashboard NewTripDashboard)
      {
        
      int? LoggedInUserId = HttpContext.Session.GetInt32("UserId");
      var LoggedInUser = dbContext.Users.FirstOrDefault(u => u.UserId == LoggedInUserId);

      if (ModelState.IsValid)
      {
        System.Console.WriteLine($">>>>>>{NewTripDashboard.UserId}{NewTripDashboard.TripName}{NewTripDashboard.StartDate}{NewTripDashboard.EndDate}<<<<<<<<<");
        Trip NewTrip = new Trip(NewTripDashboard.UserId, NewTripDashboard.TripName, NewTripDashboard.StartDate, NewTripDashboard.EndDate);

      

        dbContext.Add(NewTrip);
        dbContext.SaveChanges();

        var TripToAddToDay = dbContext.Trips.FirstOrDefault(t => t.TripName == NewTrip.TripName);

        var NumDays = (NewTrip.EndDate - NewTrip.StartDate).TotalDays;
        var DayToAdd = NewTrip.StartDate;



        for (int i = 0; i <= NumDays; i++)
        {
          Day NewDay = new Day(DayToAdd, TripToAddToDay.TripId);
          dbContext.Add(NewDay);
          dbContext.SaveChanges();
          DayToAdd = DayToAdd.AddDays(1);
        }

        return Json(NewTrip);
      }
      return Json("Error");
      
    }
  }
}