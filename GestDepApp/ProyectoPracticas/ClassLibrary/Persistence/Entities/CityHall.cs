using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace GestDep.Entities
{
    public partial class CityHall {
   
        public virtual ICollection<Person> People {
            get;
            set;
        }
     
        public virtual ICollection<Payment> Payments
        {
            get;
            set;
        }
     
        public virtual ICollection<Gym> Gyms
        {
            get;
            set;
        }
        public int Id
        {
            get;
            set;
        }
        public String Name
        {
            get;
            set;
        }
    }
}