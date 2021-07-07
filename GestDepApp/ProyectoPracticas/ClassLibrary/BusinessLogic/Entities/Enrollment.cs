using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestDep.Entities
{
    public partial class Enrollment
    {
        public Enrollment()
        {
            Payments = new List<Payment>();
        }
        public Enrollment(DateTime enrollmentDate, Activity activity,
        Payment payment, User user) : this()
        {
            CancellationDate = null;
            EnrollmentDate = enrollmentDate;
            ReturnedFirstCuotaIfCancelledActivity = null;
            //Id is managed by EE...
            Activity = activity;
            Payments.Add(payment);
            User = user;
        }
    }
}