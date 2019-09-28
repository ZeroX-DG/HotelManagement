using System;
using System.Collections.Generic;
using System.Text;
using HotelManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
         }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<CheckSheet> CheckSheets { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<HouseKeeper> HouseKeepers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Schedule> Schedules { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }


        public DbSet<HotelManagement.Models.ParkingLot> ParkingLot { get; set; }




    }
}
