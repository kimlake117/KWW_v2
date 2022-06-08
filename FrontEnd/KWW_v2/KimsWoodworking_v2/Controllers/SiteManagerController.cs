using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KimsWoodworking_v2.Models.ViewModels;
using KimsWoodworking_v2.Models;
using static KimsWoodworking_v2.Repositories.ProductRepository;

namespace KimsWoodworking_v2.Controllers
{
    [Authorize(Roles = "Manager")]
    public class SiteManagerController : Controller
    {
        private List<ProductModel> products = GetAllProducts();

        // GET: SiteManager
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch(Exception ex) {
                //need to do some loging here
                ViewBag.message = ex.Message + ex.StackTrace;
                return View("Error");
            }
        }

        public ActionResult ChooseProduct() {
            try
            {
                EditProductViewModel viewModel = new EditProductViewModel()
                {
                    ProductsList = products
                };
                return View(viewModel);
            }
            catch (Exception ex)
            {
                //need to do some loging here
                ViewBag.message = ex.Message + ex.StackTrace;
                return View("Error");
            }
        }

        public ActionResult EditProduct(int ProductID)
        {
            try
            {
                EditProductViewModel vm = new EditProductViewModel
                {
                    ProductToEdit = products.First(x => x.ProductID == ProductID)
                };

                return View(vm);
            }
            catch (Exception ex)
            {
                //need to do some loging here
                ViewBag.message = ex.Message + ex.StackTrace;
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct(EditProductViewModel vm)
        {
            try
            {
                UpdateProduct(vm);

                //refresh products list with updated data 
                products = GetAllProducts();

                return Redirect("ChooseProduct");
            }
            catch (Exception ex)
            {
                //need to do some loging here
                ViewBag.message = ex.Message + ex.StackTrace;
                return View("Error");
            }
        }
    }  
}