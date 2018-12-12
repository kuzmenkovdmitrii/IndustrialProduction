using System;
using System.Collections.Generic;

namespace Common.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public decimal Payment { get; set; }
        public int Count { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }
        public Periodicity Periodicity { get; set; }
    }
}
