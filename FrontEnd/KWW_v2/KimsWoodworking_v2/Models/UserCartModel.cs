using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KimsWoodworking_v2.Models
{
    public class UserCartModel
    {
        [Display(Name ="User ID")]
        public string UserID { get; set; } = "";

        [Display(Name = "Product ID")]
        public int ProductID { get; set; } = -1;

        [Display(Name = "Product Name")]
        public string ProductName { get; set; } = "";

        [Display(Name = "Quantity")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number.")]
        public int Quantity { get; set; } = 0;

        [Display(Name = "Price")]
        public decimal ProductPrice { get; set; } = 0;
    }
}