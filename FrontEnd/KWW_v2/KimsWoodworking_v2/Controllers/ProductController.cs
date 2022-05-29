using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KimsWoodworking_v2.Models;
using KimsWoodworking_v2.Models.ViewModels;
using static KimsWoodworking_v2.Repositories.ProductRepository;

namespace KimsWoodworking_v2.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            try
            {
                ProductIndexViewModel productIndexViewModel = new ProductIndexViewModel
                {
                    ProductsList = GetAllActiveProducts()
                };
                return View(productIndexViewModel);
            }
            catch { 
                //need to do some loging here
                return View("Error");
            }
        }
    }
}