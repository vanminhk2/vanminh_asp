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
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Xml.Linq;
    public partial class Brand
    {
        public int Id { get; set; }
        [Display(Name = "Tên thương hiệu")]
        public string Name { get; set; }
        [Display(Name = "Ảnh thương Hiệu")]
        public string Avatar { get; set; }
        [Display(Name = "Loại")]
        public string Slug { get; set; }
        [Display(Name = "hiện lên trang chủ")]
        public Nullable<bool> ShowOnHomePage { get; set; }
        [Display(Name = "thứ tự trình bày")]
        public Nullable<int> DisPlayOrder { get; set; }
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        public Nullable<System.DateTime> UpdatedonUtc { get; set; }
        public Nullable<bool> Deleted { get; set; }
        [NotMapped]
        public System.Web.HttpPostedFileBase ImageUpLoat { get; set; }
    }
}