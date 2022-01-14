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
    
    public partial class A_CancelledLoans
    {
        public int ID { get; set; }
        public string RefNumber { get; set; }
        public string Title { get; set; }
        public Nullable<int> Title_FK { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string OtherNames { get; set; }
        public string Gender { get; set; }
        public Nullable<int> Gender_FK { get; set; }
        public string MaritalStatus { get; set; }
        public Nullable<int> MaritalStatus_FK { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string BVN { get; set; }
        public string Mobilenumber { get; set; }
        public string PersonalEmail { get; set; }
        public string PermanentAddress { get; set; }
        public string PALandmark { get; set; }
        public string PAClosestbuststop { get; set; }
        public string PA_LGA { get; set; }
        public Nullable<int> PA_LGA_FK { get; set; }
        public string PA_StateofResidence { get; set; }
        public Nullable<int> PA_StateofResidence_FK { get; set; }
        public string TemporaryAddress { get; set; }
        public string TempLandmark { get; set; }
        public string TempClosestBuststop { get; set; }
        public string TempLGA { get; set; }
        public Nullable<int> TempLGA_FK { get; set; }
        public string TempState { get; set; }
        public Nullable<int> TempState_FK { get; set; }
        public string StateCode { get; set; }
        public string NYSCState { get; set; }
        public Nullable<int> NYSCState_FK { get; set; }
        public string NYSCLGA { get; set; }
        public Nullable<int> NYSCLGA_FK { get; set; }
        public string NYSCEmployer { get; set; }
        public string NYSCAddress { get; set; }
        public string ExpectedPassoutdate { get; set; }
        public string CDSDay { get; set; }
        public string CDsGroup { get; set; }
        public Nullable<double> Netmonthlyincome { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactRelationship { get; set; }
        public string EmergencyContactHomeaddress { get; set; }
        public string EmergencyContactPhonenumber { get; set; }
        public string EmergencyContactEmailAddress { get; set; }
        public Nullable<double> LoanAmount { get; set; }
        public Nullable<double> Tenure { get; set; }
        public Nullable<double> Monthsleft { get; set; }
        public Nullable<double> Monthsowed { get; set; }
        public Nullable<double> RepaymentAmount { get; set; }
        public string Anyexistingloan { get; set; }
        public Nullable<double> OutstandingAmount { get; set; }
        public Nullable<double> OutstandingMonthsLeft { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public Nullable<System.DateTime> ApplicationDate { get; set; }
        public string Status { get; set; }
        public string Reasonforcancelling { get; set; }
    }
}
