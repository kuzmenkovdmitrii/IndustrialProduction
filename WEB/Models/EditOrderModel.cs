using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Common.Entities;

namespace WEB.Models
{
    public class EditOrderModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Count")]
        [Required(ErrorMessage = "Field can't be empty")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Invalid value of count")]
        public int Count { get; set; }

        public List<Product> Products { get; set; }

        public List<DateTime> Days { get; set; }
    }
}