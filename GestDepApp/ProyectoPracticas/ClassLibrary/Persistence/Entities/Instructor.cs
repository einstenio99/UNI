using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [InverseProperty("Instructor")]
        public virtual ICollection<Activity> Activities {
            get;
            set;
        }
    }
}