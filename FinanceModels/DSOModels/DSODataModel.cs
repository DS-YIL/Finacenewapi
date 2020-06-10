using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceModels.DSOModels
{
   public class DSODataModel
    {
        public string region { get; set; }
        public DateTime reportdate { get; set; }
        public string division { get; set; }
        public decimal CECI { get; set; }
        public decimal PCI { get; set; }
        public decimal PCIANA { get; set; }
        public decimal SERVICE { get; set; }
        public decimal SOLUTION { get; set; }
        public decimal SYSTEMS { get; set; }
        public decimal TAS { get; set; }
        public decimal TMI { get; set; }
    }
    public class DSODivisionModel
    {
        public string Division { get; set; }
        public decimal Bangalore { get; set; }
        public decimal Bangladesh { get; set; }
        public decimal Baroda { get; set; }
        public decimal Chennai { get; set; }
        public decimal Kochi { get; set; }
        public decimal Kolkatta { get; set; }
        public decimal Nagpur { get; set; }
        public decimal Mumbai { get; set; }
        public decimal Delhi { get; set; }
    }
}
