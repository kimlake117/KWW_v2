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
        public static List<ProductModel> GetUserCart() {     
            
            DynamicParameters p = new DynamicParameters();

            p.Add("@UserID", System.Web.HttpContext.Current.User.Identity.GetUserId());

            string sql = "exec [dbo].[GetUserCart] @UserID";

            return DataAccess.LoadDataList<ProductModel>(sql,p);
        }
        public static int AddProductToCartByID(int productID)
        {
            if (!IsProductInCart(productID)) {
                UserCartModel userCartItem = new UserCartModel();

                userCartItem.ProductID = productID;
                userCartItem.Quantity = 1;
                userCartItem.UserID = System.Web.HttpContext.Current.User.Identity.GetUserId();

                string sql = "[dbo].[InsertProductIntoCart] @ProductID,@Quantity,@UserID";

                return DataAccess.SaveData(sql,userCartItem);
            }
            return -1;
        }

        public static bool IsProductInCart(int productID)
        {
            bool result = false;

            List<ProductModel> userCart = GetUserCart();

            foreach (ProductModel product in userCart)
            {
                if(product.ProductID == productID){
                    result = true;
                }
            }

            return result;
        }
    } 
}