using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class EmployeeClass
    {
        public int id { get; set; }
        public string name { get; set; }
        public int salary { get; set; }
        public int Age { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
        public string Email { get; set; }
        public int exist { get; set; }

        public virtual List<Bill> Bill { get; set; }

    }
}
