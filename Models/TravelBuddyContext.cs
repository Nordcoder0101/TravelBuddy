using Microsoft.EntityFrameworkCore;

namespace TravelBuddy.Models
{
  public class TravelBuddyContext : DbContext
  {
    public TravelBuddyContext(DbContextOptions<TravelBuddyContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Flight> Flights {get;set;}
    public DbSet<RoadTrip> RoadTrips {get;set;}
    public DbSet<Trip> Trips {get;set;}
    public DbSet<Day> Days {get;set;}
    public DbSet<ActivityAndDay> ActivityAndDays {get;set;}

  }

}