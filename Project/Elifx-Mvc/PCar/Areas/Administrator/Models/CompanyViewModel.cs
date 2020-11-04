using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PCar.Areas.Administrator.Models
{
    public class CompanyViewModel
    {
        public int ID { get; set; }

        public string LanguageID { get; set; }

        [DisplayName("Tên Company")]
        [Required(ErrorMessage = "Vui lòng nhập tên")]
        [MaxLength(300, ErrorMessage = "Tối đa 250 ký tự")]
        public string CompanyName { get; set; }

        [DisplayName("Logo")]
        [Required(ErrorMessage = "Vui lòng chọn logo")]
        public string Logo { get; set; }

        [DisplayName("Ảnh đại diện")]
        [Required(ErrorMessage = "Vui lòng chọn ảnh đại diện")]
        public string Image { get; set; }

        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [MaxLength(100, ErrorMessage = "Tối đa 100 ký tự")]
        public string Phone { get; set; }

        [DisplayName("Hotline")]
        [Required(ErrorMessage = "Vui lòng nhập Hotline")]
        [MaxLength(100, ErrorMessage = "Tối đa 100 ký tự")]
        public string Hotline { get; set; }
 

        [DisplayName("Địa chỉ email")]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ email")]
        [EmailAddress(ErrorMessage = "vui lòng nhập đúng địa chỉ email")]
        public string Email { get; set; }

        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        [MaxLength(300, ErrorMessage = "Tối đa 250 ký tự")]
        public string Address { get; set; }

        [DisplayName("Vị trí khách sạn trên google")]
        [MaxLength(50, ErrorMessage = "Tối đa 50 ký tự")]
        public string Location { get; set; }


        [DisplayName("Website")]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ website ")]
        [MaxLength(300, ErrorMessage = "Tối đa 100 ký tự")]
        public string Website { get; set; }


        [DisplayName("Link trang facebook")]
        [MaxLength(300, ErrorMessage = "Tối đa 250 ký tự")]
        public string FaceBook { get; set; }

        [DisplayName("Link Instagram")]
        [MaxLength(300, ErrorMessage = "Tối đa 250 ký tự")]
        public string Instagram { get; set; }

        [DisplayName("Link twitter")]
        [MaxLength(300, ErrorMessage = "Tối đa 250 ký tự")]
        public string Twitter { get; set; }   
        
        [DisplayName("Link zalo")]
        [MaxLength(300, ErrorMessage = "Tối đa 250 ký tự")]
        public string zalo { get; set; }

        [DisplayName("Link youtube")]
        [MaxLength(300, ErrorMessage = "Tối đa 250 ký tự")]
        public string Youtube { get; set; }

        [DisplayName("Copyright")]
        [Required(ErrorMessage = "Vui lòng nhập copyright")]
        [MaxLength(300, ErrorMessage = "Tối đa 300 ký tự")]
        public string CopyRight { get; set; }

        [DisplayName("Tiêu đề trang")]
        [MaxLength(300, ErrorMessage = "Tối đa 250 ký tự")]
        public string MetaTitle { get; set; }

        [DisplayName("Thẻ mô tả")]
        [MaxLength(300, ErrorMessage = "Tối đa 250 ký tự")]
        public string MetaDescription { get; set; }

        [DisplayName("Term & Condition")]
        [Required(ErrorMessage = "Vui lòng nhập Term & Condition")]
        public string Condition { get; set; }
        public string Description { get; set; }

    }
}