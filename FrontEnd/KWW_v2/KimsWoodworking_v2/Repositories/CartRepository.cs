using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KimsWoodworking_v2.Models;
using Dapper;
using Microsoft.AspNet.Identity;

namespace KimsWoodworking_v2.Repositories
{
    public static class CartRepository
    {
        public static List<UserCartModel> GetUserCart() {     
            
            DynamicParameters p = new DynamicParameters();

            p.Add("@UserID", System.Web.HttpContext.Current.User.Identity.GetUserId());

            string sql = "exec [dbo].[GetUserCart] @UserID";

            return DataAccess.LoadDataList<UserCartModel>(sql,p);
        }
        public static int AddProductToCartByID(int productID)
        {
            if (!IsProductInCart(productID)) {
                UserCartModel userCartItem = new UserCartModel
                {
                    ProductID = productID,
                    Quantity = 1,
                    UserID = System.Web.HttpContext.Current.User.Identity.GetUserId()
                };

                string sql = "[dbo].[InsertProductIntoCart] @ProductID,@Quantity,@UserID";

                return DataAccess.SaveData(sql,userCartItem);
            }
            return -1;
        }

        public static bool IsProductInCart(int productID)
        {
            bool result = false;

            List<UserCartModel> userCart = GetUserCart();

            foreach (UserCartModel product in userCart)
            {
                if(product.ProductID == productID){
                    result = true;
                }
            }

            return result;
        }

        public static int DeleteFromCart(int productID) {
            UserCartModel UserCartItem = new UserCartModel
            {
                ProductID = productID,
                UserID = System.Web.HttpContext.Current.User.Identity.GetUserId()
            };

            string sql = "[dbo].[DeleteFromCart] @ProductID, @UserID";

            return DataAccess.SaveData(sql, UserCartItem);
        }

        public static int UpdateCartItemQuantity(int productID, int newQuantity) {

            if (newQuantity > 0)
            {
                UserCartModel UserCartItem = new UserCartModel
                {
                    ProductID = productID,
                    Quantity = newQuantity,
                    UserID = System.Web.HttpContext.Current.User.Identity.GetUserId()
                };


                string sql = "exec [dbo].[UpdateCartItem] @ProductID, @Quantity, @UserID";


                return DataAccess.SaveData(sql, UserCartItem);
            }
            else {
                UserCartModel UserCartItem = new UserCartModel
                {
                    ProductID = productID,
                    Quantity = newQuantity,
                    UserID = System.Web.HttpContext.Current.User.Identity.GetUserId()
                };


                string sql = "exec [dbo].[DeleteFromCart] @ProductID, @UserID";


                return DataAccess.SaveData(sql, UserCartItem);
            }
        }

        public static decimal GetCartTotalPrice() { 
            decimal totalPrice = 0;

            List<UserCartModel> userCart = GetUserCart();

            foreach (var item in userCart) {
                decimal itemTotal = item.ProductPrice * item.Quantity;
                totalPrice += itemTotal;
            }

            return totalPrice;
        }
    } 
}