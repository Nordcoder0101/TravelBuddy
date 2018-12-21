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
      if(HttpContext.Session.GetInt32("UserId")==null){
        return Redirect("/");
      }
      int? LoggedInUserId = HttpContext.Session.GetInt32("UserId");
      var LoggedInUser = dbContext.Users.FirstOrDefault(u => u.UserId == LoggedInUserId);
      List<Trip> AllTrips = dbContext.Trips.Where(t => t.UserId == LoggedInUser.UserId).ToList();
      

      UserDashboard DashboardInfo = new UserDashboard(LoggedInUser.UserId, LoggedInUser.FirstName, AllTrips);
      System.Console.WriteLine($"<<<<<<>>>>>>>>>>>{DashboardInfo.UserName}, {DashboardInfo.EndDate}, {DashboardInfo.UserId}, {DashboardInfo.TripName}><><><><><><><><><>><><><><><>");
      return View(DashboardInfo);
    }

    [HttpGet("showcreate/{id}")]
    public IActionResult ShowCreate(string id)
    {
      return PartialView($"_ShowCreate{id}");
    }
    
    [HttpGet("showcreateactivity")]
    public IActionResult ShowCreateActivity()
    {
      return PartialView("_ShowCreateActivity");
    }



    [HttpPost("createtrip")]
    public IActionResult CreateTrip(UserDashboard NewTripDashboard)
      {
        
      int? LoggedInUserId = HttpContext.Session.GetInt32("UserId");
      var LoggedInUser = dbContext.Users.FirstOrDefault(u => u.UserId == LoggedInUserId);

      if (ModelState.IsValid)
      {
        System.Console.WriteLine($@"
          >>>>>>
          {NewTripDashboard.UserId}
          {NewTripDashboard.TripName}
          {NewTripDashboard.StartDate}
          {NewTripDashboard.EndDate}
          <<<<<<<<<");

        Trip NewTrip = new Trip();
        NewTrip.UserId = LoggedInUser.UserId;
        NewTrip.TripName = NewTripDashboard.TripName;
        NewTrip.StartDate = NewTripDashboard.StartDate;
        NewTrip.EndDate = NewTripDashboard.EndDate;

        dbContext.Add(NewTrip);
        dbContext.SaveChanges();

        var TripToAddToDay = dbContext.Trips.FirstOrDefault(t => t.TripName == NewTrip.TripName);

        var NumDays = (NewTrip.EndDate - NewTrip.StartDate).TotalDays;
        var DayToAdd = NewTrip.StartDate;
        var DayOfWeek = DayToAdd.DayOfWeek.ToString();


        for (int i = 0; i <= NumDays; i++)
        {
          Day NewDay = new Day();
          NewDay.TheDay = DayToAdd;
          NewDay.DayOfTheWeek = DayOfWeek;
          NewDay.TripId = TripToAddToDay.TripId;

          dbContext.Add(NewDay);
          dbContext.SaveChanges();
          
          DayToAdd = DayToAdd.AddDays(1);
          DayOfWeek = DayToAdd.DayOfWeek.ToString();
        }

        return RedirectToAction("UserDashboard",Json(NewTrip));
      }
      return Json("Error");
      
    }
    [HttpGet("showaddroadtrip")]
    public IActionResult ShowAddRoadTrip()
    {
      return PartialView("_ShowCreateRoadTrip");
    }

    [HttpGet("delete/{id}")]
    public IActionResult DeleteTrip(int id)
    {
      var OneTrip = dbContext.Trips.FirstOrDefault(a=>a.TripId==id);
      dbContext.Remove(OneTrip);
      dbContext.SaveChanges();
      return RedirectToAction("UserDashboard");
    }


  }
}