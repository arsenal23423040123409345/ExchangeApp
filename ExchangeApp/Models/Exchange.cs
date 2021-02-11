using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeApp.Models
{
    [Serializable]
    public class Exchange
    {
        //public string Id { get; set; }
        public string FromAmount { get; set; }
        public string FromCurrency { get; set; }
        public string ToAmount { get; set; }
        public string ToCurrency { get; set; }
        public DateTime Date { get; set; }
    }
}
