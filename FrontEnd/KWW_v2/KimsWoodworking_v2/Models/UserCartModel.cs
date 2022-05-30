using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KimsWoodworking_v2.Models
{
    public class UserCartModel
    {
        public string UserID { get; set; } = "";

        public int ProductID { get; set; } = -1;

        public int Quantity { get; set; } = 0;
    }
}