//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Online_BookStore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaction
    {
        public int TransactionID { get; set; }
        public Nullable<int> CartID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> BookID { get; set; }
        public string RecieveState { get; set; }
        public Nullable<System.DateTime> time { get; set; }
        public Nullable<int> PaymentID { get; set; }
        public Nullable<System.DateTime> Expectedtimetorecieve { get; set; }
    }
}
