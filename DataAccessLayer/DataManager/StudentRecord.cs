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
    
    public partial class StudentRecord
    {
        public int ID { get; set; }
        public int Institution_FK { get; set; }
        public string MatriculationNumber { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Othernames { get; set; }
        public string DateOfBirth { get; set; }
        public Nullable<int> Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Faculty { get; set; }
        public string Deparment { get; set; }
        public Nullable<double> CreditLimit { get; set; }
        public Nullable<int> NoOfBorrows { get; set; }
        public Nullable<double> AmountBorrowed { get; set; }
        public Nullable<double> OutstandingBalance { get; set; }
        public string CustomMessage { get; set; }
        public Nullable<int> Registered { get; set; }
        public Nullable<int> IsVisible { get; set; }
    }
}
