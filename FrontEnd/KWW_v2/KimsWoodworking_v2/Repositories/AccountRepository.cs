using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using KimsWoodworking_v2.Models;

namespace KimsWoodworking_v2.Repositories
{
    public static class AccountRepository
    {
        public static bool UserNameExists(string username) { 
            bool exists = false;

            if (GetUserByName(username) != null) { 
                exists = true;
            }

            return exists;
        }

        public static UserModel GetUserByName(string username) {
            UserModel user = null;

            DynamicParameters p = new DynamicParameters();

            p.Add("@UserName", username);

            string sql = "exec [dbo].[GetUserByName] @UserName";

            List<UserModel> results = DataAccess.LoadDataList<UserModel>(sql, p);

            if (results.Count > 0)
            {
                user = results[0];
            }
                return user;
        }
    }
}