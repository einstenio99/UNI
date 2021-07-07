using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestDep.Entities
{
    public partial class Room
    {
        public Room() {
        }
        public Room(int id, int number) {
            Id = id;
            Number = number;
        }
    }

}