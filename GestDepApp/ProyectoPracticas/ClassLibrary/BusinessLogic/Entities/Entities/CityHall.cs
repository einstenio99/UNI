using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestDep.Entities
{
    public partial class CityHall {
        public ICollection<Person> Belongs {
            get;
            set;
        }
        public ICollection<Payment> Recieves
        {
            get;
            set;
        }
        public ICollection<Gym> Manages
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