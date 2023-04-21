using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webbanhang.Context;

namespace webbanhang.Models
{
    public class CartModel
    {
        internal string ProductId;
        internal int Quatity;

        public Product Product { get; set; }
        public string Quantity { get; set; }

    }
}