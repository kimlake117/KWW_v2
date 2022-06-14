using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KimsWoodworking_v2.Models.ViewModels
{
    public class CheckOutViewModel
    {
        public string UserID { get; set; }

        [Display(Name ="Billing First Name")]
        [Required]
        public string BillingFirstName { get; set; }

        [Display(Name = "Billing Last Name")]
        [Required]
        public string BillingLastName { get; set; }

        [Required]
        public string BillingStreet { get; set; }

        [Required]
        public string BillingCity { get; set; }

        [Required]
        public int BillingState { get; set; }

        [Required]
        public string BillingPostalCode { get; set; }

        [Required]
        public string CCardNumber { get; set; }

        [Required]
        public int CCMonth { get; set; }

        [Required]
        public int CCYear { get; set; }

        [Required]
        public int CVC { get; set; }

        [Required]
        public string ShippingFirstName { get; set; }

        [Required]
        public string ShippingLastName { get; set; }

        [Required]
        public string ShippingStreet { get; set; }

        [Required]
        public string ShippingCity { get; set; }

        [Required]
        public int ShippingState { get; set; }

        [Required]
        public string ShippingPostalCode { get; set; }


    }
}