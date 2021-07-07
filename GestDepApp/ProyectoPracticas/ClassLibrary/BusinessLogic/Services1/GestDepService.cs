using GestDep.Entities;
using GestDep.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestDepLib.Services1
{
    class GestDepService : IGestDepService
    {
            private readonly IDAL dal;

            public GestDepService(IDAL dal)
            {
                this.dal = dal;
            }

            public void RemoveAllData()
            {
                dal.RemoveAllData();
                throw new ServiceException();
        }

            public void Commit()
            {
                dal.Commit();
                throw new ServiceException();
        }

            public void AddCityHall(CityHall city)
            {
                dal.Insert<CityHall>(city);
                dal.Commit();
                throw new ServiceException();
        }
            public CityHall FindCityHallByName(string name) 
            {
            List<CityHall> cityhalls = new List<CityHall>(dal.GetAll<CityHall>());
             foreach(CityHall city in cityhalls)             
            {
                if (city.Name == name)
                {
                    return city;
                }          
            }
            Console.WriteLine("no se ha encontrado un ayuntamiento");
            return null;
            throw new ServiceException();
        }

        public List<CityHall> GetAllCityHalls()
        {
            List<CityHall> cityhalls = new List<CityHall>(dal.GetAll<CityHall>());
            return cityhalls;
            
        }

        public void AddGym(Gym gym) //hecho
            {
                dal.Insert<Gym>(gym);
                dal.Commit();
                throw new ServiceException();
        }


            public Gym FindGymByName(string name) //hecho
            {
            List<Gym> gyms = new List<Gym>(dal.GetAll<Gym>());
            foreach (Gym mygym in gyms)
            {
                if (mygym.Name == name)
                {
                    return mygym;
                }
            }
            //Console.WriteLine("no se ha encontrado el gym");
            throw new ServiceException("No se ha encontrado el gym");
            }
            public void AddRoom(Room room) //hecho
            {
                dal.Insert<Room>(room);
                dal.Commit();
            }
             public void GetFreeRooms(Room room) //hecho
            {
                dal.Insert<Room>(room);
                 dal.Commit();
                throw new ServiceException();
        }

            public Room FindRoom(int Number) //hecho
            {
            List<Room> room = new List<Room>(dal.GetAll<Room>());
            foreach (Room myroom in room)
            {
                if (myroom.Number == Number)
                {
                    return myroom;
                }
            }
            //Console.WriteLine("no se ha encontrado la habitación");
            throw new ServiceException("no se ha encontrado la habitación");
        }

        public Activity FindActivityByName(string name) //hecho
        {
            List<Activity> activities = new List<Activity>(dal.GetAll<Activity>());
            
            
                foreach (Activity myact in activities)
                {
                    if (myact.Description == name)
                    {
                        return myact;
                    }
                }
            //Console.WriteLine("no se ha encontrado la actividad");
            throw new ServiceException("no se ha encontrado la actividad");
        } 


        public void AddInstructor(Instructor m)
            {
                dal.Insert<Instructor>(m);
                dal.Commit();
                throw new ServiceException();
             }

        public void SetInstructor(Instructor i)
        {
            throw new ServiceException();
        }


        public Instructor FindInstructorById(int m) //hecho
        {
            try { return dal.GetById<Instructor>(m); } catch (ServiceException) {
                Console.WriteLine("no existe el instructor");
            }
            return null;
        }

        public void AddActivity(Activity activity) //hecho
            {
            if (dal.GetById<Activity>(activity.Id) == null)
            {
                dal.Insert<Activity>(activity);
                dal.Commit();
            }
            else throw new ServiceException("Dicha actividad ya existe :c");
            throw new ServiceException();
        }

            public void AddUser(User usuario)
            {
            if (dal.GetById<User>(usuario.Id) == null)
            {
                dal.Insert<User>(usuario);
                dal.Commit();
            }
            throw new ServiceException("Dicho usuario ya existe, eres tonto?");
            }

        public void AddUser(User usuario, Activity activity)
        {
            if (dal.GetById<User>(usuario.Id) == null)
            {
                dal.Insert<User>(usuario);
                dal.Commit();
            }
            throw new ServiceException("Dicho usuario ya existe, eres tonto?");
        }
            public int GetPriceForUser(Gym g, User u)
        {
            throw new ServiceException();
        }
        public void AddEnrollment(Enrollment enrollment)
        {
            if (dal.GetById<Enrollment>(enrollment.Id) == null)
            {
                dal.Insert<Enrollment>(enrollment);
                dal.Commit();
            }
            else throw new ServiceException("Dicho enrollment ya existe :c");
            throw new ServiceException();
        }
        public void AddPayment(Payment payment)
        {
            if (dal.GetById<Payment>(payment.Id) == null)
            {
                dal.Insert<Payment>(payment);
                dal.Commit();
            }
            else throw new ServiceException("Dicha persona ya existe :c");
            throw new ServiceException();
        }
        public void AddPerson(Person person)
        {
            if (dal.GetById<Person>(person.Id) == null)
            {
                dal.Insert<Person>(person);
                dal.Commit();
            }
            else throw new ServiceException("Dicha persona ya existe :c");
        }
    }
    }


