using System.Collections.Generic;

namespace IndProd.DAL.Domain
{
    class Order
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public decimal Payment { get; set; }
        public int Count { get; set; }
        public IList<Product> Products { get; set; }
        public Customer Customer { get; set; }
        public IList<Date> Days { get; set; }
    }
}
