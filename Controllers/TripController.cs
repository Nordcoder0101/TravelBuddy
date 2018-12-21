using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TravelBuddy.Models;
using TravelBuddy.HelperModels;
using System.Linq;
using Microsoft.AspNetCore.Identity;

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
      var LoggedInUser = dbContext.users.FirstOrDefault(u => u.user_id == LoggedInUserId);
      List<Trip> AllTrips = dbContext.trips.Where(t => t.user_id == LoggedInUser.user_id).ToList();
      

      UserDashboard DashboardInfo = new UserDashboard(LoggedInUser.user_id, LoggedInUser.first_name, AllTrips);
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
      var LoggedInUser = dbContext.users.FirstOrDefault(u => u.user_id == LoggedInUserId);

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
        NewTrip.user_id = LoggedInUser.user_id;
        NewTrip.name = NewTripDashboard.TripName;
        NewTrip.start_date = NewTripDashboard.StartDate;
        NewTrip.end_date = NewTripDashboard.EndDate;

        dbContext.Add(NewTrip);
        dbContext.SaveChanges();

        var TripToAddToDay = dbContext.trips.FirstOrDefault(t => t.name == NewTrip.name);

        var NumDays = (NewTrip.end_date - NewTrip.start_date).TotalDays;
        var DayToAdd = NewTrip.start_date;
        var DayOfWeek = DayToAdd.DayOfWeek.ToString();


        for (int i = 0; i <= NumDays; i++)
        {
          Day NewDay = new Day();
          NewDay.date = DayToAdd;
          NewDay.trip_id = TripToAddToDay.trip_id;

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
      var OneTrip = dbContext.trips.FirstOrDefault(a=>a.trip_id==id);
      dbContext.Remove(OneTrip);
      dbContext.SaveChanges();
      return RedirectToAction("UserDashboard");
    }


  }
}