using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PCar.Areas.Administrator.Models
{
    public class MailConfig
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Port")]
        public int Port { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Vui lòng nhập email")]
        [EmailAddress(ErrorMessage = "Vui lòng nhập đúng địa chỉ email")]
        public string Email { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Smtp")]
        [Required(ErrorMessage = "Vui lòng nhập host")]
        public string Smtp { get; set; }
    }
}