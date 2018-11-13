using System;
using System.Collections.Generic;

namespace IndProd.BLL.DTO
{
    public class OrderDTO
    {
        public int? Id { get; set; }
        public string Status { get; set; }
        public decimal? Payment { get; set; }
        public int? Count { get; set; }
        public IList<ProductDTO> Products { get; set; }
        public UserDTO User { get; set; }
        public IList<DateTime> Days { get; set; }
    }
}
