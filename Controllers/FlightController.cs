using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TravelBuddy.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;

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
        createNew.airline_name = newFlight.Airline;
        createNew.arrival_date = newFlight.Arrival;
        createNew.arrival_city = newFlight.ArrivalCity;
        createNew.departing_state = newFlight.DepartingState;
        createNew.departing_city = newFlight.DepartingCity;
        createNew.arrival_city = newFlight.ArrivalCity;
        createNew.arrival_city = newFlight.ArrivalCity;
        

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