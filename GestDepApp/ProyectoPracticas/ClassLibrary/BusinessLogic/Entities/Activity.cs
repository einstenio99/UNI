    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestDep.Entities;
using GestDep.Persistence;
using GestDep.Services;


namespace GestDep.Entities

{
    public partial class Activity
    {
        public Activity()
        {

            Enrollments = new List<Enrollment>();
            Rooms = new List<Room>();
            

        }
        public Activity(Days activityDays, string description, TimeSpan duration,
            DateTime finishDate, int maximumEnrollments, int minimumEnrollments, double price,
            DateTime startDate, DateTime startHour)
        {
            
            ActivityDays = activityDays;
            Description = description;
            Duration = duration;
            FinishDate = finishDate;
            MaximumEnrollments = maximumEnrollments;
            MinimumEnrollments = minimumEnrollments;
            Price = price;
            StartDate = startDate;
            StartHour = startHour;
            Enrollments = new List<Enrollment>();
            Rooms = new List<Room>();

            if ((StartDate > FinishDate)) { throw new ServiceException("EL SISTEMA NO ACEPTA QUE LA FECHA INICIAL SEA SUPERIOR A LA FINAL"); }
            if ((StartDate <= DateTime.Today)) { throw new ServiceException("LA FECHA INICIAL DEBE SER SUPERIOR AL DÍA DE HOY " + "(" + StartDate.ToShortDateString() + ")"); }
        }
        public void AddRoom(Room room)
        {
            foreach(Activity a in room.Activities)
            {
                if ((this.StartDate <= a.StartDate && this.FinishDate >= a.StartDate) || (this.StartDate >= a.StartDate && this.StartDate <= a.FinishDate)) {
                    if ((a.ActivityDays & this.ActivityDays) == this.ActivityDays)
                    {

                        if ((this.StartHour <= a.StartHour && (this.StartHour + this.Duration) >= a.StartHour) ||
                        (this.StartHour >= a.StartHour && this.StartHour <= ((a.StartHour) + a.Duration)))
                        {
                            throw new ServiceException("LOS HORARIOS PARA LA SALA " + room.Number + " ESTAN SOLAPADOS");
                        }
                    }

                }
            }
            this.Rooms.Add(room);
            
        } 

        public void SetInstructor(Instructor i)
        {
            if(this.Instructor != null) { throw new ServiceException("ESTA ACTIVIDAD YA TIENE UN INSTRUCTOR"); }
            foreach(Activity a in i.Activities)
            {
                if ((this.StartDate <= a.StartDate && FinishDate >= a.StartDate) || (this.StartDate >= a.StartDate && this.StartDate <= a.FinishDate))
                {
                    if ((a.ActivityDays & this.ActivityDays) == this.ActivityDays)
                    {
                        if ((this.StartHour <= a.StartHour && (this.StartHour + this.Duration) >= a.StartHour) ||
                            (this.StartHour >= a.StartHour && this.StartHour <= ((a.StartHour) + a.Duration)))
                        {
                            throw new ServiceException("NO ES POSIBLE AÑADIR A " + i.Name + " DEBIDO A QUE EL HORARIO DE LA ACTIVIDAD A LA QUE SE " +
                                "LE QUIERE ASIGNAR ESTÁ SOLAPADO CON LA ACTIVIDAD " + a.Description);
                        }
                    }
                }
            }
            this.Instructor = i;
        }
        public double GetPriceForUser(Gym g, User u)
        {
            double p = Price;
            try
            {
                if (u.Retired) { p -= g.DiscountRetired; }
                if (u.ZipCode == g.ZipCode) { p -= g.DiscountLocal; }
                return p;
            } catch (Exception){ throw new ServiceException("NO ES POSIBLE OBTENER EL PRECIO"); }
        }
    }
}