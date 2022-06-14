using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KimsWoodworking_v2.Models.ViewModels
{
    public class SuccessfulOrderViewModel
    {
        public int ParentOrderID { get; set; }

        public decimal TotalOrderCost { get; set; }
    }
}