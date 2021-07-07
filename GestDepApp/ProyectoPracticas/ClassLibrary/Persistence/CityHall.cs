using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestDep.Entities
{
    public partial class CityHall
    {
        public CityHall() { 
        Belongs = new List<Person>();
        Recieves = new List<Payment>();
        Manages = new List<Gym>();
        }
        public CityHall(int id, String name) {
            Id = id;
            Name = name;
        }
    }
}