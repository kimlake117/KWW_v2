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
    [Authorize]
    public class CartController : Controller
    {
        private List<UserCartModel> UserCart = GetUserCart();
        private Decimal TotalCartPrice = Math.Round(GetCartTotalPrice(), 2);
        // GET: Cart
        public ActionResult Index()
        {
            try
            {
                if (TotalCartPrice == 0) {
                    ViewBag.TotalPrice = "0.00";
                }
                else {
                    ViewBag.TotalPrice = TotalCartPrice;
                }

                return View(UserCart);
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

        public ActionResult ConfirmCart() {
            try
            {
                if (UserCart.Count < 1) {
                    ViewBag.NoItemsInCartMessage = "No Items in cart.";
                    ViewBag.TotalPrice = "0.00";
                    return View("Index",UserCart);
                }
                else {
                    ViewBag.TotalPrice = TotalCartPrice;
                    return View(UserCart); 
                }
            }
            catch (Exception ex)
            {
                //need to do some loging here
                ViewBag.message = ex.Message + ex.StackTrace;
                return View("Error");
            }
        }

        public ActionResult CheckOut() {
            try
            {
                return View();
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
        public ActionResult CheckOut(CheckOutViewModel vm) {
            try
            {
                return View();
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