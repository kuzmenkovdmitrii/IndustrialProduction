using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WEB.Models
{
    public class ProductModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Поле Name не может быть пустым")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Не верная длина")]
        public string Name { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Field can't be empty")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Invalid value of count")]
        public decimal Price { get; set; }
    }
}