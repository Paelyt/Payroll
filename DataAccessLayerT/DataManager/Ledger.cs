//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayerT.DataManager
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ledger
    {
        public int ID { get; set; }
        public string RepaymentDate { get; set; }
        public Nullable<double> Debit { get; set; }
        public Nullable<double> Credit { get; set; }
        public Nullable<byte> RepaymentFlag { get; set; }
        public string LoanReference { get; set; }
        public Nullable<int> LedgerFlag { get; set; }
        public System.DateTime Created { get; set; }
        public Nullable<int> DefaultCount { get; set; }
        public Nullable<double> DefaultAmount { get; set; }
    }
}
