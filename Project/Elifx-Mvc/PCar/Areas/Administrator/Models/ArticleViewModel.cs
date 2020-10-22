using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCar.Areas.Administrator.Models
{
    public class ArticleViewModel
    {

        public int ID { get; set; }

        [DisplayName("Chuyên mục bài viết")]
        [Required(ErrorMessage = "Vui lòng chọn chuyên mục bài viết")]
        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn chuyên mục bài viết")]
        public int MenuID { get; set; }

        [DisplayName("Tiêu đề bài viết")]
        [Required(ErrorMessage = "Vui lòng nhập tiêu đề bài viết")]
        [MaxLength(250, ErrorMessage = "Tối đa 250 ký tự")]
        public string Title { get; set; }

        [DisplayName("Thuộc Menu")]
        public string TitleMenu { get; set; }

        [DisplayName("Alias")]
        [MaxLength(250, ErrorMessage = "Tối đa 250 ký tự")]
        public string Alias { get; set; }

        [DisplayName("Ảnh đại diện")]
        [MaxLength(300, ErrorMessage = "Tối đa 300 ký tự")]
        public string Image { get; set; }

        [DisplayName("Mô tả")]
        [AllowHtml]
        public string Description { get; set; }

        [DisplayName("Nội dung bài viết")]
        [Required(ErrorMessage = "Vui lòng nhập nội dung")]
        [AllowHtml]
        public string Content { get; set; }

        public int? Index { get; set; }

        [DisplayName("Tiêu đề trang")]
        [MaxLength(350, ErrorMessage = "Tối đa 350 ký tự")]
        public string MetaTitle { get; set; }

        [DisplayName("Thẻ mô tả")]
        [MaxLength(550, ErrorMessage = "Tối đa 550 ký tự")]
        public string MetaDescription { get; set; }

        [DisplayName("Trạng thái hiển thị")]
        public bool Status { get; set; }

        [DisplayName("Hiển thị trang chủ")]
        public bool Home { get; set; }

        [DisplayName("Bài viết giới thiệu")]
        public bool About { get; set; }

        [DisplayName("Bài viết KH")]
        public bool Customer { get; set; }

        [DisplayName("Bài viết mới")]
        public bool New { get; set; }

        [DisplayName("Bài viết hot")]
        public bool Hot { get; set; }



        public DateTime DateTime { get; set; }
    }
}