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
    
    public partial class NYSCReferralLedger
    {
        public int ID { get; set; }
        public Nullable<int> User_FK { get; set; }
        public string ReferralCode { get; set; }
        public Nullable<System.DateTime> TrnDate { get; set; }
        public string ReferenceNumber { get; set; }
        public Nullable<double> Debit { get; set; }
        public Nullable<double> Credit { get; set; }
        public string ValueDate { get; set; }
        public string ValueTime { get; set; }
        public Nullable<int> IsVisible { get; set; }
        public string Audit { get; set; }
    }
}
