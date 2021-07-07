using GestDep.Entities;
using GestDep.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestDepLib.Services1
{
    interface IGestDepService
    {
        void RemoveAllData();
        void Commit();
        void AddCityHall(CityHall city);
        void AddGym(Gym gym);
        void AddRoom(Room room);
        void AddInstructor(Instructor m);
        void AddActivity(Activity activity);
        void AddUser(User usuario);
        void AddUser(User usuario, Activity activity);
        void AddPerson(Person person);
        void AddPayment(Payment payment);
        void AddEnrollment(Enrollment enrollment);
        CityHall FindCityHallByName(string name); 
        Instructor FindInstructorById(int id);
        Room FindRoom(int id);
        Activity FindActivityByName(string name);
        Gym FindGymByName(string name);
        List<CityHall> GetAllCityHalls();
        int GetPriceForUser(Gym g, User u);
        void SetInstructor(Instructor i); 



    }
}
