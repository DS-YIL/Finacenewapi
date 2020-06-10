using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceModels.DomainModels
{
    public class ChildMenu
    {
        public Int32 MenuId { get; set; }
        public Int32 ParentMenuId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string CssFont { get; set; }
    }
}
