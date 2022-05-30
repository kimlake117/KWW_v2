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
    }
}