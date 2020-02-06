using System;

namespace Z2H_Demo_WebApiForBalanceAdjustment
{
    public class CustomerBalance
    {
        public int CustomerNumber { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}
