using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PCar.Areas.Administrator.Models
{
    public class MenuViewModel
    {
        public int ID { get; set; }
        [DisplayName("Tiêu đề Menu")]
        public string Title { get; set; }
        [DisplayName("Thứ tự hiển thị")]
        public int? Index { get; set; }
        [DisplayName("Kiểu menu")]
        public string TypeMenu { get; set; }
        [DisplayName("Trạng thái")]
        public bool Status { get; set; }

        [DisplayName("Hiển thị ở thanh Menu")]
        public bool IsMenu { get; set; }
        public bool? Hot { get; set; }

        public int Level { get; set; }
    }
}