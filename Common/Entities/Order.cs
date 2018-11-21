using System;
using System.Collections.Generic;

namespace Common.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public decimal Payment { get; set; }
        public int Count { get; set; }
        public IList<Product> Products { get; set; }
        public User User { get; set; }
        public IList<DateTime> Days { get; set; }
    }
}
