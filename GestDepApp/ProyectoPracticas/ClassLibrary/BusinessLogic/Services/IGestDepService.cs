using GestDep.Entities;
using GestDep.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestDep.Services
{
    public interface IGestDepService
    {
        void RemoveAllData(); 
        void Commit();
        void AddCityHall(CityHall city);
        void AddGym(Gym gym);
        void AddInstructor(Instructor m);
        void AddActivity(Activity activity);
        void AddUser(User usuario);
        void AddEnrollment(Enrollment enrollment); 
        Instructor FindInstructorById(string name);
        CityHall FindCityHallByName(string name);
        List<CityHall> GetAllCityHalls();
        List<Enrollment> GetAllEnrollments();
        List<Activity> GetAllActivities();
        User FindUserById(string v);
    }
}
