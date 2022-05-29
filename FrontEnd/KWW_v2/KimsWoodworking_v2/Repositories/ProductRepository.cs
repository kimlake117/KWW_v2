using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KimsWoodworking_v2.Models;
using Dapper;

namespace KimsWoodworking_v2.Repositories
{
    public static class ProductRepository
    {
        public static List<ProductModel> GetAllProducts() {

            DynamicParameters p = new DynamicParameters();

            string sql = "exec [dbo].[GetAllActiveProducts]";

            return DataAccess.LoadDataList<ProductModel>(sql,p);
        }

        public static List<ProductModel> GetAllActiveProducts()
        {

            DynamicParameters p = new DynamicParameters();

            string sql = "exec [dbo].[GetAllActiveProducts]";

            return DataAccess.LoadDataList<ProductModel>(sql, p);
        }
    }
}