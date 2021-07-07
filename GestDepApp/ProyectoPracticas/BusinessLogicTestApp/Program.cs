using System;
using System.Data.Entity.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestDep.Persistence;
using GestDep.Entities;
using GestDep.Services;
using System.IO.Ports;

namespace BusinessLogicTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IGestDepService service = new GestDepService(new EntityFrameworkDAL(new GestDepDbContext()));

                new Program(service);
            }
            catch (Exception e)
            {
                printError(e);
                Console.WriteLine("Press any key.");
                Console.ReadLine();
            }


        }

        static void printError(Exception e)
        {
            while (e != null)
            {
                if (e is DbEntityValidationException)
                {
                    DbEntityValidationException dbe = (DbEntityValidationException)e;

                    foreach (var eve in dbe.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                                ve.PropertyName,
                                eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                                ve.ErrorMessage);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("ERROR: " + e.Message);
                }
                e = e.InnerException;
            }
        }


        private IGestDepService service;

        Program(IGestDepService service)
        {
            this.service = service;

            service.RemoveAllData();

            // Adding Pool and Lanes
            AddCityHallGymAndRooms();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

                // Adding Courses
                AddActivities();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                // Adding Instructors
                AddInstructors();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                // Adding Users and Enrollments
                AddUsers();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                // Adding payments
                AddPayments();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                // Testing Free Lanes
                TestingFreeRooms();
                Console.Out.WriteLine("\nPress any key to finish.");
                Console.In.ReadLine();

        }

        void AddCityHallGymAndRooms()
        {
            Console.WriteLine();
            Console.WriteLine("ADDING CITYHALL, GYM AND ROOMS...");

            try
            {
                CityHall c = new CityHall("Valencia");
                service.AddCityHall(c);

                //public Gym(DateTime closingHour, int discountLocal, int discountRetired, double freeUserPrice, String name, DateTime openingHour, int zipCode)
                Gym g = new Gym(Convert.ToDateTime("14:00:00"), 5, 5, 2.00, "Gym1", Convert.ToDateTime("08:00:00"), 46122);
                c.AddGym(g);

                for (int j = 1; j < 7; j++)
                {
                    Room r = new Room(j);
                    g.AddRoom(r);
                }
                service.AddGym(g);

                foreach (CityHall ci in service.GetAllCityHalls())
                {
                    Console.WriteLine("CityHall: " + ci.Name);
                    foreach (Gym gy in ci.Gyms)
                    {
                        Console.WriteLine(" Gym: " + gy.Name);
                        foreach (Room r in gy.Rooms)
                            Console.WriteLine("   Room: " + r.Number);
                    }
                }
            }
            catch(Exception e)
            {
                printError(e);
            }
        }

        
        void AddActivities()
        {
            Console.WriteLine();
            Console.WriteLine("ADDING ACTIVITIES AND ASSIGNING ROOMS...");

            CityHall c = service.FindCityHallByName("Valencia");

            Gym g = c.FindGymByName("Gym1");
            try
            {

                // Activity(Days activityDays, String description, TimeSpan duration, DateTime finishDate, int maximumEnrollments, int minimumEnrollments, double price, DateTime startDate, DateTime startHour)
                Activity a = new Activity(Days.Mon | Days.Wed | Days.Fri, "Yoga 101", new TimeSpan(0, 45, 0), new DateTime(2021, 3, 12), 20, 6, 100, new DateTime(2021, 2, 8), Convert.ToDateTime("09:30:00"));
                g.AddActivity(a);
                service.AddActivity(a);

                Console.WriteLine("Activity days");
                Console.Out.WriteLine("  " + a.ActivityDays);
                if ((a.ActivityDays & Days.Fri) == Days.Fri)
                    Console.WriteLine("   Activity is on Friday");
                else
                    Console.WriteLine("   Activity is NOT on Friday");

                // Adding Rooms for an Activity
                a.AddRoom(g.FindRoom(3));
                a.AddRoom(g.FindRoom(4));
                a.AddRoom(g.FindRoom(5));
                service.Commit();

                // Testing rooms assigned
                Console.WriteLine("\nRooms assigned to " + a.Description);
                foreach (Room ro in a.Rooms)
                    System.Console.WriteLine("   " + ro.Number + " assigned");

                // Adding another Activity
                a = new Activity(Days.Mon | Days.Wed | Days.Fri, "Zumba 101", new TimeSpan(0, 45, 0), new DateTime(2021, 5, 31), 20, 6, 100, new DateTime(2021, 3, 3), Convert.ToDateTime("09:30:00"));
                g.AddActivity(a);
                service.AddActivity(a);

                // Adding Rooms for an Activity
                g = c.FindGymByName("Gym1");
                a.AddRoom(g.FindRoom(1));
                a.AddRoom(g.FindRoom(6));
                service.Commit();

                a.AddRoom(g.FindRoom(5));
                service.Commit();

            }
            catch (Exception e)
            {
                printError(e);
            }

            try
            {
                // Adding another Activity
                Activity a = new Activity(Days.Mon | Days.Wed | Days.Fri, "Disco 101", new TimeSpan(0, 45, 0), new DateTime(2021, 5, 31), 20, 6, 100, new DateTime(2021, 7, 3), Convert.ToDateTime("09:30:00"));
                g.AddActivity(a);
                service.AddActivity(a);
            }
            catch (Exception e)
            {
                printError(e);
            }

            try
            {
                // Adding another Activity
                Activity a = new Activity(Days.Mon | Days.Wed | Days.Fri, "Jazz 101", new TimeSpan(0, 45, 0), new DateTime(2021, 7, 30), 20, 6, 100, DateTime.Today, Convert.ToDateTime("09:30:00"));
                g.AddActivity(a);
                service.AddActivity(a);
            }
            catch (Exception e)
            {
                printError(e);
            }


        }

        void AddInstructors()
        {
            Console.WriteLine();
            Console.WriteLine("ADDING INSTRUCTORS...");

            try
            {
                CityHall c = service.FindCityHallByName("Valencia");

                Gym g = c.FindGymByName("Gym1");

                // Instructor(String address, String IBAN, String id, String name, int zipCode, String ssn)
                Instructor i = new Instructor("Xuan-Lan's address", "ES891234121234567891", "00000001R", "Xuan Lan", 46001, "SSN01010101");
                c.AddPerson(i);
                service.AddInstructor(i);

                Activity a = g.FindActivityByName("Yoga 101");
                a.SetInstructor(i);
                service.Commit();
                Console.WriteLine("   " + a.Instructor.Name + " assigned to " + a.Description + " activity"); ;

                i = new Instructor("Mercedes de la Rosa's address", "ES891234121234567892", "00000002W", "Mercedes de la Rosa", 46002, "SSN02020202");
                c.AddPerson(i);
                service.AddInstructor(i);

                i = new Instructor("Keila Velón's address", "ES891234121234567893", "00000003A", "Keila Velón", 46003, "SSN03030303");
                c.AddPerson(i);
                service.AddInstructor(i);

                a = g.FindActivityByName("Zumba 101");
                i = service.FindInstructorById("00000001R"); // Podría hacerse desde CityHall
                a.SetInstructor(i);
                service.Commit();
                Console.WriteLine("   " + a.Instructor.Name + " assigned to " + a.Description + " activity"); ;
            }
            catch (Exception e)
            {
                printError(e);
            }
        }
        void AddUsers()
        {
            Console.WriteLine();
            Console.WriteLine("ADDING USERS...");

            try
            {
                CityHall c = service.FindCityHallByName("Valencia");

                Gym g = c.FindGymByName("Gym1");

                Activity a = g.FindActivityByName("Yoga 101");

                // User(String address, String IBAN, String id, String name, int zipCode, DateTime birthDate, bool retired)
                User u = new User("Cansado Perpetuo's address", "ES891234121234567890", "123456789B", "Cansado Perpetuo", 46002, new DateTime(1990, 6, 5), false);
                c.AddPerson(u);
                service.AddUser(u);
                double priceForUser = a.GetPriceForUser(g, u);
                // Payment(DateTime date, string description, double quantity)
                Payment p = new Payment(DateTime.Today, "First quota", priceForUser);
                c.AddPayment(p);
                // Enrollment(DateTime enrollmentDate, Activity activity, Payment payment, User user)
                Enrollment e = new Enrollment(new DateTime(2020, 09, 16), a, p, u);
                service.AddEnrollment(e);

                u = new User("Faemino Saavedra's address", "ES891234121234567891", "123456780W", "Faemino Saavedra", 46002, new DateTime(1979, 4, 12), false);
                c.AddPerson(u);
                service.AddUser(u);
                priceForUser = a.GetPriceForUser(g, u);
                p = new Payment(DateTime.Today, "First quota", priceForUser);
                c.AddPayment(p);
                e = new Enrollment(new DateTime(2020, 10, 08), a, p, u);
                service.AddEnrollment(e);

                u = new User("Rubén Doblas Gundersen's address", "ES891234121234567892", "123456782W", "Rubén Doblas Gundersen", 46003, new DateTime(1990, 2, 13), false);
                c.AddPerson(u);
                service.AddUser(u);
                priceForUser = a.GetPriceForUser(g, u);
                p = new Payment(DateTime.Today, "First quota", priceForUser);
                c.AddPayment(p);
                e = new Enrollment(new DateTime(2020, 09, 28), a, p, u);
                service.AddEnrollment(e);

                u = new User("Rigoberto's address", "ES891234121234567893", "123456783M", "Rigoberto", 46122, new DateTime(1995, 2, 28), false);
                c.AddPerson(u);
                service.AddUser(u);
                priceForUser = a.GetPriceForUser(g, u);
                p = new Payment(DateTime.Today, "First quota", priceForUser);
                c.AddPayment(p);
                e = new Enrollment(new DateTime(2020, 10, 02), a, p, u);
                service.AddEnrollment(e);

                u = new User("Lazaro's address", "ES891234121234567894", "567890123K", "Lazaro", 46122, new DateTime(1900, 1, 1), true);
                c.AddPerson(u);
                service.AddUser(u);
                priceForUser = a.GetPriceForUser(g, u);
                p = new Payment(DateTime.Today, "First quota", priceForUser);
                c.AddPayment(p);
                e = new Enrollment(new DateTime(2017, 09, 29), a, p, u);
                service.AddEnrollment(e);

                // Checking Users enrolled
                Console.WriteLine("  Users enrolled in the activity " + a.Description + " with instructor " + a.Instructor.Name);
                foreach (Enrollment en in a.Enrollments)
                    Console.WriteLine("   " + en.User.Name + " enrolled");
            }
            catch (Exception e)
            {
                printError(e);
            }
        }


        void AddPayments()
        {
            Console.WriteLine();
            Console.WriteLine("ADDING PAYMENTS...");

            try
            {
                CityHall c = service.FindCityHallByName("Valencia");

                Gym g = c.FindGymByName("Gym1");

                //Payment p = new Payment(new DateTime(2020, 9, 10, 18, 12, 5), "Free User", g.FreeUserPrice);
                //c.AddPayment(p);
                //service.AddPayment(p);

                //p = new Payment(new DateTime(2020, 9, 10, 18, 12, 6), "Free User", g.FreeUserPrice);
                //c.AddPayment(p);
                //service.AddPayment(p);

                //p = new Payment(new DateTime(2020, 9, 20, 18, 13, 5), "Free User", g.FreeUserPrice);
                //c.AddPayment(p);
                //service.AddPayment(p);

                //// Adding Payments
                //Activity a = g.FindActivityByName("Yoga 101");

                //Enrollment e = a.FindEnrollment("123456789B");
                //p = new Payment(new DateTime(2020, 8, 16, 12, 30, 0), "Quota", e.Activity.GetPriceForUser(g, e.User));
                //c.AddPayment(p);
                //e.AddPayment(p);
                //service.AddPayment(p);

                //p = new Payment(new DateTime(2020, 8, 17, 13, 30, 1), "Quota", e.Activity.GetPriceForUser(g, e.User));
                //c.AddPayment(p);
                //e.AddPayment(p);
                //service.AddPayment(p);

                //e = a.FindEnrollment("567890123K");
                //p = new Payment(new DateTime(2020, 9, 29, 11, 24, 15), "Quota", e.Activity.GetPriceForUser(g, e.User));
                //c.AddPayment(p);
                //e.AddPayment(p);
                //service.AddPayment(p);

                // Testing Payments
                foreach (Enrollment en in service.GetAllEnrollments())
                {
                    Console.WriteLine("\n  Payments attached to " + en.User.Name);
                    foreach (Payment moO in en.Payments)
                        Console.WriteLine("   " + moO.Description + " " + moO.Quantity);
                }

                //Console.WriteLine("\n  Free Swim payments");
                //foreach (Payment pa in service.GetAllFreeUserPayments())
                //    Console.WriteLine("   " + pa.Quantity + " " + pa.Date);

            }
            catch (Exception e)
            {
                printError(e);
            }
        }

        void TestingFreeRooms()
        {
            Console.WriteLine();
            Console.WriteLine("TESTING FREE LANES");

            try
            {
                CityHall c = service.FindCityHallByName("Valencia");

                Gym g = c.FindGymByName("Gym1");
                
                // Test free lanes week 2021, 3, 10
                int freeLanes = g.GetFreeRooms(new DateTime(2021, 3, 10, 8, 00, 0), Days.Wed);
                Console.WriteLine("   Free lanes 10/03/21 at 8:00 - " + freeLanes);

                freeLanes = g.GetFreeRooms(new DateTime(2021, 3, 10, 9, 30, 0), Days.Wed);
                Console.WriteLine("   Free lanes 10/03/21 at 9:30 - " + freeLanes);

            }
            catch (Exception e)
            {
                printError(e);
            }
        }



    }

}


