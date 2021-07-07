using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestDep.Entities
{
    public partial class Activity
    {
        public Activity() {

        Has = new List<Enrollment>();
        Alocates = new List<Room>();
        this.Manages = instructor;

        }
        public Activity(Days activityDays, Boolean cancelled, string description, TimeSpan duration,
            DateTime finishDate, int id, int maximumEnrollments, int minimumEnrollments, double price,
            DateTime startDate, DateTime startHour){
            
            ActivityDays = activityDays;
            Cancelled = cancelled;
            Description = description;
            Duration = duration;
            FinishDate = finishDate;
            Id = id;
            MaximumEnrollments = maximumEnrollments;
            MinimumEnrollments = minimumEnrollments;
            Price = price;
            StartDate = startDate;
            StartHour = startHour;
            Has = new List<Enrollment>();
            Alocates = new List<Room>();
            this.Manages = instructor;
        }
    } 
}