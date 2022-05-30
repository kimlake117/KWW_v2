using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using KimsWoodworking_v2.Models;

namespace KimsWoodworking_v2.Models.ViewModels
{
    public class UserCartViewModel
    {
       public List<ProductModel> ProductsInCartList { get; set; } = new List<ProductModel>();
    }
}