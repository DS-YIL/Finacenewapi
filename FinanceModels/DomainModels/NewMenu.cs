using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceModels.DomainModels
{
    public class NewMenu
    {
        public int MenuId { get; set; }
        public int PrentId { get; set; }
        public string Title { get; set;}
        public string Description { get; set; }
        public string Url { get; set; }
        public List<NewMenu> MenuList { get; set; }

    }
}