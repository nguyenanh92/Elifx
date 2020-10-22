using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCar.Areas.Administrator.Models
{
    public class MenuCheck
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Level { get; set; }
        public string Checked { get; set; }
    }
}