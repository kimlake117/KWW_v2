using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KimsWoodworking_v2.Models
{
    public class ProductModel
    {
        [Display(Name ="Product Number")]
        public int ProductID { get; set; } = -1;

        [Display(Name = "Product Name")]
        public string ProductName { get; set; } = "";

        [Display(Name = "Product Price")]
        public decimal ProductPrice { get; set; } = decimal.Zero;

        [Display(Name = "Description")]
        public string ProductDescription { get; set; } = "";

        [Display(Name = "Active")]
        public bool Active { get; set; } = false;

        [Display(Name = "Quantity")]
        public int Quantity { get; set; } = 0;
    }
}