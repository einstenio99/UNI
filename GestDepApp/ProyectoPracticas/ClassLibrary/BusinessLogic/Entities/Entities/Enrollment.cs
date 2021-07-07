using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestDep.Entities
{
    public partial class Enrollment
    {
        public DateTime? CancellationDate
        {
            get;
            set;
        }
        public DateTime EnrollmentDate
        {
            get;
            set;
        }

        public int Id
        {
            get;
            set;
        }
        public DateTime? ReturnedFirstCuotaIfCancelledActivity
        {
            get;
            set;
        }
        //Associations
        public virtual Activity Activity
        {
            get;
            set;
        }
        public virtual ICollection<Payment> Payments
        {
            get;
            set;
        }
        public virtual User User
        {
            get;
            set;
        }
    }
}