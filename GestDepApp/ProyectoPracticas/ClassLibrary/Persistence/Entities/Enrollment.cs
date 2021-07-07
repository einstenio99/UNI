using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [InverseProperty("Enrollments")]
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
        [InverseProperty("Enrollments")]
        public virtual User User
        {
            get;
            set;
        }
    }
}