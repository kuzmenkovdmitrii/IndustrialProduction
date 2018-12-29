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

        [Display(Name = "Количество")]
        [Required(ErrorMessage = "Field can't be empty")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Invalid value of count")]
        public int Count { get; set; }

        public int ProductId { get; set; }

        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }

        public bool OnceAWeek { get; set; }
        public bool TwiceAWeek { get; set; }
        public bool ThreeTimesAWeek { get; set; }
        public bool OnceAMonth { get; set; }
    }
}