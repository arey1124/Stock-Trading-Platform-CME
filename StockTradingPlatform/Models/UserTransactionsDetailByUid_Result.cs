//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StockTradingPlatform.Models
{
    using System;
    
    public partial class UserTransactionsDetailByUid_Result
    {
        public int tid { get; set; }
        public string reqType { get; set; }
        public string stockName { get; set; }
        public Nullable<int> qty { get; set; }
        public Nullable<decimal> reqPrice { get; set; }
        public Nullable<System.DateTime> time { get; set; }
    }
}