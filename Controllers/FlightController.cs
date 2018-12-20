using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TravelBuddy.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Data.Entity;

namespace TravelBuddy.Controllers
{
  public class FlightController : Controller
  {
    private TravelBuddyContext dbContext;

    public FlightController(TravelBuddyContext context)
    {
      dbContext = context;

    }

    [HttpGet("showcreateflight/{id}")]
    public IActionResult ShowCreateFlight(string id)
    {
      return PartialView($"_ShowCreate{id}");
    }

    [HttpPost("createflight")]
    public IActionResult CreateFlight(FlightValidation newFlight)
    {
      if (ModelState.IsValid)
      {
        Flight createNew = new Flight();
        createNew.Arrival = newFlight.Arrival;
        createNew.ArrivalCity = newFlight.ArrivalCity;

        System.Console.WriteLine(">>>>>>>>>>>HERE<<<<<<<<<<<<<");
        dbContext.Add(createNew);
        dbContext.SaveChanges();
        return Json(createNew);
      }
      else
      {
        return View();
      }

    }
  }
}