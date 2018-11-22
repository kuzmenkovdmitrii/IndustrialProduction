using System.Web.Mvc;
using Common.Entities;

namespace WEB.Models
{
    public class OrderModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Status { get; set; }
        public decimal Payment { get; set; }
        public int Count { get; set; }
        public Product Product { get; set; }
    }
}