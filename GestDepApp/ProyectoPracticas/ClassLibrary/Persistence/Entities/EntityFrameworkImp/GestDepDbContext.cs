using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestDep.Entities;

namespace GestDep.Persistence

//namespace GestDep.Persistence.Entities.EntityFrameworkImp
{
    public class GestDepDbContext : DbContextISW
    {
        public DbSet<CityHall> CityHalls { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Gym> Gyms  { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public GestDepDbContext() : base("Name=GestDepDbConnection") { }

    }
}
