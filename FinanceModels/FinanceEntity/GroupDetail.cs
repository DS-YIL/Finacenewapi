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
    
    public partial class GroupDetail
    {
        public int GroupID { get; set; }
        public string Group_Name { get; set; }
        public string Group_Description { get; set; }
        public int RoleID { get; set; }
        public string DeleteFlag { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        public virtual AccessRole AccessRole { get; set; }
    }
}
