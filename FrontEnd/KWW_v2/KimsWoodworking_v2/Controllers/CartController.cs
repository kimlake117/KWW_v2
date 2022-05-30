using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KimsWoodworking_v2.Models.ViewModels;
using static KimsWoodworking_v2.Repositories.CartRepository;

namespace KimsWoodworking_v2.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        [Authorize]
        public ActionResult Index()
        {
            try
            {
                UserCartViewModel UserCart = new UserCartViewModel
                {
                    ProductsInCartList = GetUserCart()
                };

                return View(UserCart);
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