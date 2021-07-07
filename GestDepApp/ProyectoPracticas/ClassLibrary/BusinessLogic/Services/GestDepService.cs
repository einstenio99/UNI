using GestDep.Entities;
using GestDep.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestDep.Services
{
    public class GestDepService : IGestDepService
    {
        private readonly IDAL dal;

        public GestDepService(IDAL dal)
        {
            this.dal = dal;
        }

        public void RemoveAllData()
        {
            try {
                dal.RemoveAllData();
            } catch (Exception) { throw new ServiceException(); }
        }

        public void Commit()
        {
            try {
                dal.Commit();
            } catch (Exception) { throw new ServiceException(); }
        }

        public void AddCityHall(CityHall city)
        {
          
                List<CityHall> ch = new List<CityHall>(dal.GetAll<CityHall>());
                if (ch.Count == 0) { dal.Insert<CityHall>(city); dal.Commit(); return; }
                foreach (CityHall ye in ch)
                {
                    if (ye.Id == city.Id)
                    {
                        throw new ServiceException("EL AYUNTAMIENTO " + city.Name + " YA EXISTE");
                    }
                }
                dal.Insert<CityHall>(city);
                dal.Commit();     
        }


        public List<CityHall> GetAllCityHalls()
        {
            List<CityHall> cityhalls = new List<CityHall>(dal.GetAll<CityHall>());
            return cityhalls;

        }
        public List<Enrollment> GetAllEnrollments()
        {
            List<Enrollment> enrollments = new List<Enrollment>(dal.GetAll<Enrollment>());
            return enrollments;

        }
        public void AddGym(Gym gym)
        {
                List<Gym> gs = new List<Gym>(dal.GetAll<Gym>());
                if (gs.Count == 0) { dal.Insert<Gym>(gym); dal.Commit(); return; }
                foreach (Gym g in gs)
                {
                    if (gym.Name == g.Name && gym.ZipCode == g.ZipCode) //GIMNASIO CON EL MISMO NOMBRE EN EL MISMO CODIGO POSTAL, SE INTENTA AÑADIR UN GIMNASIO QUE YA ESTÁ
                    {
                        throw new ServiceException("EL GIMNASIO " + gym.Name + " YA EXISTE");
                    }
                }
                dal.Insert<Gym>(gym);
                dal.Commit();
        }
        public CityHall FindCityHallByName(string name) 
        {
            List<CityHall> cities = new List<CityHall>(dal.GetAll<CityHall>());
            foreach (CityHall c in cities)
            {
                if (c.Name == name)
                {
                    return c;
                }
            }
            throw new ServiceException("NO SE HA ENCONTRADO EL AYUNTAMIENTO " + name);
        }

        public void AddInstructor(Instructor m)
        {
                List<Instructor> ins = new List<Instructor>(dal.GetAll<Instructor>());
                if (ins.Count == 0) { dal.Insert<Instructor>(m); dal.Commit(); return; }
                foreach (Instructor i in ins)
                {
                    if (i.Id == m.Id)
                    {
                        throw new ServiceException("EL INSTRUCTOR " + m.Name + " YA EXISTE");
                    }
                }
                dal.Insert<Instructor>(m);
                dal.Commit();
        }

        public Instructor FindInstructorById(string v) 
        {
            try { return dal.GetById<Instructor>(v); } catch (Exception) { throw new ServiceException("NO SE HA ENCONTRADO AL INSTRUCTOR " + v); }
        }

        public void AddActivity(Activity activity) 
        {
                List<Activity> acts = new List<Activity>(dal.GetAll<Activity>());
                if(acts.Count == 0) { dal.Insert<Activity>(activity); dal.Commit(); return; }
                foreach (Activity a in acts)
                {
                    if (a.Id == activity.Id)
                    {
                    throw new ServiceException("LA ACTIVIDAD " + activity.Description + " YA EXISTE");
                    }
                }
                dal.Insert<Activity>(activity);
                dal.Commit();
        }

        public void AddUser(User usuario)
        {
                List<User> usr = new List<User>(dal.GetAll<User>());
                if (usr.Count == 0) { dal.Insert<User>(usuario); dal.Commit(); return; }
                foreach (User u in usr)
                {
                    if (u.Id == usuario.Id)
                    {
                        throw new ServiceException("EL USUARIO" + usuario.Name + " YA EXISTE");
                    }
                }
                dal.Insert<User>(usuario);
                dal.Commit();
        }

        public void AddEnrollment(Enrollment enrollment)
        {
                List<Enrollment> quique = new List<Enrollment>(dal.GetAll<Enrollment>());
                if(quique.Count == 0) { dal.Insert<Enrollment>(enrollment); dal.Commit(); return; }
                foreach(Enrollment victor in quique)
                {
                    if ((victor.User.Id == enrollment.User.Id && victor.Activity.Id == enrollment.Activity.Id))
                    {
                        throw new ServiceException("LA INSCRIPCIÓN YA EXISTE");
                    }
                }
                dal.Insert<Enrollment>(enrollment);
                dal.Commit();
        }
        public List<Activity> GetAllActivities() 
        {
            List<Activity> acts = new List<Activity>(dal.GetAll<Activity>());
            foreach(Activity a in acts)
            {
                if(a.FinishDate < DateTime.Today) { acts.Remove(a); }
            }
            if (acts.Count == 0) { throw new ServiceException("NO EXISTEN ACTIVIDADES EN EL SISTEMA"); }
            return acts;
        }

        public User FindUserById(string v)
        {
            User xd = dal.GetById<User>(v);
            if (xd == null) {throw new ServiceException("FALLO USER"); }
            return xd;
        }
    }
}


