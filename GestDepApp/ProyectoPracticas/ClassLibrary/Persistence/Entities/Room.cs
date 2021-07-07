using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestDep.Entities
{
    public partial class Room
    {
        public int Id
        {
            get;
            set;
        }
        public int Number
        {
            get;
            set;
        }

        [InverseProperty("Rooms")]
        public virtual ICollection<Activity> Activities
        {
            get;
            set;
        }
    }
}