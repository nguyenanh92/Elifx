using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DataLibrary.Database;

namespace PCar.Areas.Administrator.Models
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }

        [DisplayName("Tên Sản Phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập tến sản phẩm")]

        public string ProductName { get; set; }

        [DisplayName("Thuộc chuyên mục ")]
        public string NameTypeMenu { get; set; }
        public string LanguageID { get; set; }
        

        public string[] TypeMenuID { get; set; }

        [DisplayName("Chuyên mục")]
        [Required(ErrorMessage = "Vui lòng chọn chuyên mục")]
        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn chuyên mục")]
        public int MenuID { get; set; }

        public string Alias { get; set; }

        [DisplayName("Ảnh đại diện")] public string Image { get; set; }

        [DisplayName("Ảnh khi hover")] public string Image2 { get; set; }

        [DisplayName("Hãng SX")]

        public string Producer { get; set; }

        [DisplayName("Giá bán")]

        [Required(ErrorMessage = "Vui lòng nhập giá sản phẩm")]
        public double Price { get; set; }
        [DisplayName("Giá Khuyến mãi")]
        public float PromotionPrice { get; set; }
        [DisplayName("Mô tả")]
        public string Description { get; set; }
        [DisplayName("Tiêu đề trang")]

        public string MetaTitle { get; set; }
        [DisplayName("Thẻ mô tả")]

        public string MetaDescription { get; set; }
        [DisplayName("Nội dung chi tiết SP")]

        public string Content { get; set; }
        [DisplayName("Chuyên mục")]

        public string Categories { get; set; }
        [DisplayName("Trạng thái hiển thị")]
        public bool Status { get; set; }
        [DisplayName("Sản phẩm nổi bật")]
        public bool Hot { get; set; }
        [DisplayName("Hiển thị trang chủ")]
        public bool Home { get; set; }
        public int Index { get; set; }

        //public List<EGalleryITem> EGalleryITems { get; set; }

        //public List<ProductGallery> ProductGalleries { get; set; }

        //public class EGalleryITem
        //{
        //    public int ProductGalleryId { get; set; }
        //    public int ProductID { get; set; }
        //    public string ImageLarge { get; set; }
        //    public string ImageSmall { get; set; }
        //    public string Image { get; set; }

        //}
    }
}