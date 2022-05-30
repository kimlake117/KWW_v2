using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KimsWoodworking_v2.Models.ViewModels;
using static KimsWoodworking_v2.Repositories.CartRepository;
using KimsWoodworking_v2.Models;

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
                ViewBag.TotalPrice = GetCartTotalPrice();

                return View(GetUserCart());
            }
            catch (Exception ex)
            {
                //need to do some loging here
                ViewBag.message = ex.Message + ex.StackTrace;
                return View("Error");
            }
        }

        public ActionResult AddProductToCart(int productID) {
            try
            {

                AddProductToCartByID(productID);


                return Redirect("Index");
            }
            catch (Exception ex)
            {
                //need to do some loging here
                ViewBag.message = ex.Message + ex.StackTrace;
                return View("Error");
            }
        }

        public ActionResult Delete(int productID) {
            try
            {
                DeleteFromCart(productID);


                return Redirect("Index");
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
        public ActionResult UpdateCartItem(UserCartModel item) {
            try
            {
                UpdateCartItemQuantity(item.ProductID, item.Quantity);

                return Redirect("Index");
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