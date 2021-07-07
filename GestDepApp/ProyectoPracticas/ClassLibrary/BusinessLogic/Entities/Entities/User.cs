using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestDep.Entities
{
    public partial class User : Person
    {
        public DateTime BirthDate
        {
            get;
            set;
        }

        public bool Retired
        {
            get;
            set;
        }
        /* Associations*/
        public virtual ICollection<Enrollment> Enrolls
        {
            get;
            set;
        }
    }
}