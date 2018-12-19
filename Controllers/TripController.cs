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

    [HttpGet("userdashboard")]
    public IActionResult UserDashboard(Trip NewTrip)
    {
      int? LoggedInUserId = HttpContext.Session.GetInt32("UserId");
      var LoggedInUser = dbContext.Users.FirstOrDefault(u => u.UserId == LoggedInUserId);
      List<Trip> AllTrips = dbContext.Trips.Where(t => t.UserId == LoggedInUser.UserId).ToList();
      

      UserDashboard DashboardInfo = new UserDashboard(LoggedInUser.UserId, LoggedInUser.FirstName, AllTrips);
      System.Console.WriteLine($"<<<<<<>>>>>>>>>>>{DashboardInfo.UserName}, {DashboardInfo.EndDate}, {DashboardInfo.UserId}, {DashboardInfo.TripName}><><><><><><><><><>><><><><><>");
      return View(DashboardInfo);
    }

    [HttpGet("showcreatetrip")]
    public IActionResult ShowCreateTrip()
    {
      return PartialView("_ShowCreateTrip");
    }


    [HttpPost("createtrip")]
    public IActionResult CreateTrip(UserDashboard NewTripDashboard)
      {
        
      int? LoggedInUserId = HttpContext.Session.GetInt32("UserId");
      var LoggedInUser = dbContext.Users.FirstOrDefault(u => u.UserId == LoggedInUserId);

      if (ModelState.IsValid)
      {
        System.Console.WriteLine($">>>>>>{NewTripDashboard.UserId}{NewTripDashboard.TripName}{NewTripDashboard.StartDate}{NewTripDashboard.EndDate}<<<<<<<<<");
        Trip NewTrip = new Trip(LoggedInUser.UserId, NewTripDashboard.TripName, NewTripDashboard.StartDate, NewTripDashboard.EndDate);

      

        dbContext.Add(NewTrip);
        dbContext.SaveChanges();

        var TripToAddToDay = dbContext.Trips.FirstOrDefault(t => t.TripName == NewTrip.TripName);

        var NumDays = (NewTrip.EndDate - NewTrip.StartDate).TotalDays;
        var DayToAdd = NewTrip.StartDate;
        var DayOfWeek = DayToAdd.DayOfWeek.ToString();

        


        for (int i = 0; i <= NumDays; i++)
        {
          Day NewDay = new Day(DayToAdd, DayOfWeek, TripToAddToDay.TripId);
          dbContext.Add(NewDay);
          dbContext.SaveChanges();
          DayToAdd = DayToAdd.AddDays(1);
          DayOfWeek = DayToAdd.DayOfWeek.ToString();
        }

        return Json(NewTrip);
      }
      return Json("Error");
      
    }
    [HttpGet("showaddroadtrip")]
    public IActionResult ShowAddRoadTrip()
    {
      return PartialView("_ShowCreateRoadTrip");
    }

  }
}