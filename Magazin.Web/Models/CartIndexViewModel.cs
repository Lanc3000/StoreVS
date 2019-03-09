using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Magazin.Domain.Entities;

namespace Magazin.Web.Models
{
    public class CartIndexViewModel
    {
        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}