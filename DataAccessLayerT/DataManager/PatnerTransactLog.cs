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
    
    public partial class PatnerTransactLog
    {
        public int ID { get; set; }
        public string PatnerCode { get; set; }
        public string PatnerUrl { get; set; }
        public string PatnerResponse { get; set; }
        public string PatnerReference { get; set; }
        public string BankAcct { get; set; }
        public string BankName { get; set; }
        public string RefNum { get; set; }
        public string MandateID { get; set; }
        public string BankCode { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string ValueDate { get; set; }
        public string ValueTime { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string ContactPerson { get; set; }
        public string InitialDebitRequestId { get; set; }
    }
}
