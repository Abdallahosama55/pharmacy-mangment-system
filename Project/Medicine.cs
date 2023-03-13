using Project;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project

{
    public class Medicine
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public double CompanyPrice { get; set; }
        public double Profit { get; set; }
        public string Type { get; set; }
        public int quantity { get; set; }
        public int exist { get; set; }

        [ForeignKey("company")]
        public int CompID { get; set; }


        public DateTime ExpDate { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime EnteredDate { get; set; }

        public virtual Company company { get; set; }

        public virtual List<MedBills> MedBills { get; set; }

    }
}
