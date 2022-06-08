using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KimsWoodworking_v2.Models;

namespace KimsWoodworking_v2.Models.ViewModels
{
    public class EditProductViewModel
    {
        public List<ProductModel> ProductsList = new List<ProductModel>();

        public ProductModel ProductToEdit { get; set; } = new ProductModel();
    }
}