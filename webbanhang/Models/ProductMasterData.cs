using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace webbanhang.Models
{
    public partial class ProductMasterData
    {
        public int id { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }
        [Display(Name = "Hình ảnh")]
        public string Avatar { get; set; }
        [Display(Name = "Tên Danh mục")]
        public Nullable<int> Categoryid { get; set; }
        [Display(Name = "Mô tả ngắn")]
        public string ShortDes { get; set; }
        [Display(Name = "Mô tả đầy đủ")]
        public string FullDescription { get; set; }
        [Display(Name = "Giá")]
        public Nullable<double> Price { get; set; }
        [Display(Name = "Giá khuyến mãi")]
        public Nullable<double> PriceDiscount { get; set; }
        [Display(Name = "Loại sản phẩm")]
        public Nullable<int> Typeid { get; set; }
        public string Slug { get; set; }
        [Display(Name = "Tên thương hiệu")]
        public Nullable<int> Brandid { get; set; }
        public Nullable<bool> Deleted { get; set; }
        [Display(Name = "Hiển thị trang chủ")]
        public Nullable<bool> ShowOnHomePage { get; set; }
        public Nullable<int> DisplayOder { get; set; }
        [Display(Name = "Ngày tạo")]
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        [Display(Name = "Ngày sửa")]
        public Nullable<System.DateTime> UpdateOnUtc { get; set; }

    }


}