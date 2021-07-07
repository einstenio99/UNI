using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestDep.Entities
{   
public partial class User : Person{
        public User() { 
            Enrollments = new List<Enrollment>(); 
        } public User(string address, string iban, string id, string name, int zipCode,
            DateTime birthDate, bool retired) 
            : base(address, iban, id, name, zipCode) {
            BirthDate = birthDate;
            Retired = retired;
            Enrollments = new List<Enrollment>();
        }
    }
    
}