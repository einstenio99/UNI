using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestDep.Entities
{
    public partial class Instructor:Person
    {
        public string Ssn{
            get;
            set;
        }

        public ICollection<Activity> Manages {
            get;
            set;
        }
    }
}