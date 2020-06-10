﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceModels.DomainModels
{
   public class LastSixMonthDataModel
    {
        public Int32 Flag { get; set; }
        public string Division { get; set; }
        public int EmployeeNo { get; set; }
        public string Region { get; set; }
        public string Month { get; set; }
        //public string Year { get; set; }
    }
}
