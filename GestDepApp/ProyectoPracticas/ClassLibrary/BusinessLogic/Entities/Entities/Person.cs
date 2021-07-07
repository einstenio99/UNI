using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestDep.Entities
{
    public partial class Person
    {
        public string Address
        {
            get;
            set;
        }
        public string IBAN
        {
            get;
            set;
        }
        public string Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public int ZipCode
        {
            get;
            set;
        }
    }
}
