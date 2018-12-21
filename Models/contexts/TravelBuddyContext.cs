using Microsoft.EntityFrameworkCore;

namespace TravelBuddy.Models
{
  public class TravelBuddyContext : DbContext
  {
    public TravelBuddyContext(DbContextOptions<TravelBuddyContext> options) : base(options) { }
    public DbSet<User> users { get; set; }
    public DbSet<Flight> flights {get;set;}
    public DbSet<Trip> trips {get;set;}
    public DbSet<Day> days {get;set;}

  }

}