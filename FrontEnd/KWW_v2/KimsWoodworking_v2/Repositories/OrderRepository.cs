using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KimsWoodworking_v2.Models;
using KimsWoodworking_v2.Models.ViewModels;
using Dapper;
using Microsoft.AspNet.Identity;


namespace KimsWoodworking_v2.Repositories
{
    public static class OrderRepository
    {
        public static SuccessfulOrderViewModel CreateOrder(CheckOutViewModel vm) {
            vm.UserID = System.Web.HttpContext.Current.User.Identity.GetUserId();

            string sql = @"exec [dbo].[CreateOrder] @UserID,@BillingFirstName,@BillingLastName,@BillingStreet,
                            @BillingCity,@BillingState,@BillingPostalCode,@CCardNumber,@CCMonth,@CCYear,@CVC,
                            @ShippingFirstName,@ShippingLastName,@ShippingStreet,@ShippingCity,@ShippingState,
                            @ShippingState";

             DataAccess.SaveData(sql, vm);

            DynamicParameters p = new DynamicParameters();

            p.Add("@UserID", System.Web.HttpContext.Current.User.Identity.GetUserId());

            sql = "exec [dbo].[GetMostRecentOrderDetails] @UserID";

            List<SuccessfulOrderViewModel> successfulOrderViewModelList = DataAccess.LoadDataList<SuccessfulOrderViewModel>(sql,p);

            SuccessfulOrderViewModel successfulOrderViewModel = new SuccessfulOrderViewModel { 
                ParentOrderID = successfulOrderViewModelList.First().ParentOrderID,
                TotalOrderCost = successfulOrderViewModelList.First().TotalOrderCost
            };

            return successfulOrderViewModel;
        }
    }
}