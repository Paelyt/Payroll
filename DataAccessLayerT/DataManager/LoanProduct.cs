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
    
    public partial class LoanProduct
    {
        public int ID { get; set; }
        public int Institution_FK { get; set; }
        public Nullable<int> LoanType_FK { get; set; }
        public string ProductCode { get; set; }
        public string LoanProduct1 { get; set; }
        public Nullable<double> LoanAmount { get; set; }
        public Nullable<double> InterestValue { get; set; }
        public Nullable<double> RepaymentAmount { get; set; }
        public Nullable<int> LoanTenure_FK { get; set; }
        public Nullable<int> MaxLoanTenure { get; set; }
        public Nullable<int> GracePeriod { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string ValueDate { get; set; }
        public string ValueTime { get; set; }
        public Nullable<int> User_FK { get; set; }
        public Nullable<int> IsVisible { get; set; }
    }
}
