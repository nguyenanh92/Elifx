using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PCar.Areas.Administrator.Models
{
    public class GalleryModelView
    {
        public int ID { get; set; }

        [DisplayName("Tên ảnh")]
        public string Title { get; set; }

        public int? Index { get; set; }

        [DisplayName("Hình ảnh")]
        [Required(ErrorMessage = "Vui lòng lựa chọn hình ảnh")]
        public string Image { get; set; }
    }
}