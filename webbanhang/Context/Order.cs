﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace webbanhang.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Order
    {
        public int Id { get; set; }
        [Display(Name = "Tên Đơn Hàng")]
        public string Name { get; set; }
        [Display(Name = "MÃ Người dùng")]
        public Nullable<int> Productid { get; set; }
        [Display(Name = "tình trạng")]
        public Nullable<double> Price { get; set; }
        public Nullable<int> Status { get; set; }
        [Display(Name = "Ngày Mua Hàng")]
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
    }
}
