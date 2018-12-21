using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TravelBuddy.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace TravelBuddy.Controllers
{
  public class LoginRegController : Controller
  {
    private TravelBuddyContext dbContext;

    public LoginRegController(TravelBuddyContext context)
    {
      dbContext = context;

    }


    [HttpGet]
    [Route("")]
    public IActionResult Login()
    {
      return View();
    }


    [HttpPost("RegisterUser")]
    public IActionResult RegisterUser(UserValidation user)
    {
      if (ModelState.IsValid)
      {
        if (dbContext.users.Any(u => u.email == user.Email))
        {
          ModelState.AddModelError("Email", "Email already in use!");
          return View("Login");
        }
        else
        {
          User newUser = new User();
          newUser.first_name = user.FirstName;
          newUser.last_name = user.LastName;
          newUser.email = user.Email;

          PasswordHasher<User> Hasher = new PasswordHasher<User>();
          newUser.password = Hasher.HashPassword(newUser, user.Password);

          dbContext.Add(newUser);
          dbContext.SaveChanges();

          var AddedUser = dbContext.users.FirstOrDefault(u => u.email == user.Email);
          HttpContext.Session.SetInt32("UserId", AddedUser.user_id);
          int? LoggedInUserId = HttpContext.Session.GetInt32("UserId");

          return RedirectToAction("UserDashboard", "Trip");
        }
      }
      else
      {
        return View("Login");
      }
    }

    [HttpGet("ViewLoginUser")]
    public IActionResult ViewLoginUser()
    {
      return View();
    }

    [HttpPost("LoginUser")]
    public IActionResult LoginUser(LoginUser UserSubmission)
    {
      if (ModelState.IsValid)
      {
        var UserToCheck = dbContext.users.FirstOrDefault(u => u.email == UserSubmission.LoginEmail);
        if (UserToCheck == null)
        {
          ModelState.AddModelError("LoginEmail", "Invalid Email or Password");
          return View("login");
        }
        var hasher = new PasswordHasher<LoginUser>();

        var result = hasher.VerifyHashedPassword(UserSubmission, UserToCheck.password, UserSubmission.LoginPassword);

        if (result == 0)
        {
          ModelState.AddModelError("LoginPassword", "Invalid Email or Password");
          return View("login");
        }
        HttpContext.Session.SetInt32("UserId", UserToCheck.user_id);
        int? LoggedInUserId = HttpContext.Session.GetInt32("UserId");
        return RedirectToAction("UserDashboard", "Trip");
      }
      return View("login");
    }

    [HttpGet("logout")]
    public IActionResult Logout()
    {
      HttpContext.Session.Clear();
      return View("Login");
    }
  }


}

