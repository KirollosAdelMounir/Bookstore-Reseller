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
    
    public partial class CreditCard
    {
        public int CardID { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public System.DateTime ExpiryDate { get; set; }
    }
}
