//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinanceModels.FinanceEntity
{
    using System;
    using System.Collections.Generic;
    
    public partial class DsoMaster
    {
        public int id { get; set; }
        public string Division { get; set; }
        public string Region { get; set; }
        public Nullable<System.DateTime> ReportDate { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public string Type { get; set; }
        public string Glaccount { get; set; }
    }
}
