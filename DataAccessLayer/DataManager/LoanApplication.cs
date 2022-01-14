//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer.DataManager
{
    using System;
    using System.Collections.Generic;
    
    public partial class LoanApplication
    {
        public int ID { get; set; }
        public string LoanRefNumber { get; set; }
        public Nullable<int> LoanProduct_FK { get; set; }
        public Nullable<int> Title_FK { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Othernames { get; set; }
        public Nullable<int> Gender_FK { get; set; }
        public Nullable<int> MaritalStatus_FK { get; set; }
        public Nullable<int> MeansOfID_FK { get; set; }
        public string IdentficationNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string ContactAddress { get; set; }
        public string Landmark { get; set; }
        public string ClosestBusStop { get; set; }
        public Nullable<int> StateofResidence_FK { get; set; }
        public Nullable<int> LGA_FK { get; set; }
        public Nullable<int> AccomodationType_FK { get; set; }
        public string Organization { get; set; }
        public string ApplicantID { get; set; }
        public string NOK_FullName { get; set; }
        public string NOK_Relationship { get; set; }
        public string NOK_PhoneNumber { get; set; }
        public string NOK_EmailAddress { get; set; }
        public string NOK_HomeAddress { get; set; }
        public Nullable<double> LoanAmount { get; set; }
        public Nullable<int> LoanTenure { get; set; }
        public Nullable<int> RepaymentMethod_FK { get; set; }
        public Nullable<bool> ExistingLoan { get; set; }
        public Nullable<double> ExistingLoan_OutstandingAmount { get; set; }
        public Nullable<int> ExistingLoan_NoOfMonthsLeft { get; set; }
        public string BankCode { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string BVN { get; set; }
        public string ValueDate { get; set; }
        public string ValueTime { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public Nullable<int> ApplicationStatus_FK { get; set; }
        public string LoanComment { get; set; }
        public Nullable<int> IsVisible { get; set; }
        public string CreatedBy { get; set; }
    }
}
