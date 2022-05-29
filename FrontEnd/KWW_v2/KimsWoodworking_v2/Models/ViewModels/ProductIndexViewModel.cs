using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KimsWoodworking_v2.Models;

namespace KimsWoodworking_v2.Models.ViewModels
{
    public class ProductIndexViewModel
    {
        public List<ProductModel> ProductsList { get; set; } = new List<ProductModel>();
    }
}