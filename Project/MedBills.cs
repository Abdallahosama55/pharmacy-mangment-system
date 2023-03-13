using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class MedBills
    {
        public int Id { get; set; }

        public string MedicineName { get; set; }

        public double UnitPrice { get; set; }
        public double TotalProfit { get; set; }

        public double TotalPrice { get; set; }
        public int exist { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public string EmployeeName { get; set; }

        [ForeignKey("Medicine")]
        public int MedId { get; set; }
        [ForeignKey("Bill")]
        public int BillId { get; set; }

        public virtual Bill Bill { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}
