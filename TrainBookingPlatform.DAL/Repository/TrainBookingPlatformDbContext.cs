using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainBookingPlatform.DAL.Entities;

namespace TrainBookingPlatform.DAL.Repository
{
    public class TrainBookingPlatformDbContext : DbContext
    {
        public TrainBookingPlatformDbContext(DbContextOptions<TrainBookingPlatformDbContext> options) : base(options)
        {
            
        }
        public DbSet<Departure> Departures { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<Wagon> Wagons { get; set; }
    }
}
