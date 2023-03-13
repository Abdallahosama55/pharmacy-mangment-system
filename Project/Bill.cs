using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Bill
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public int exist { get; set; }


        [ForeignKey("Employee")]

        public int EmpId { get; set; }

        public virtual EmployeeClass Employee { get; set; }

        public virtual List<MedBills> MedBills { get; set; }



    }
}
