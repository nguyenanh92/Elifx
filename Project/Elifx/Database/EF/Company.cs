namespace Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Company")]
    public partial class Company
    {
        public int ID { get; set; }

        [StringLength(300)]
        public string CompanyName { get; set; }

        public int? Phone { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(10)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public int? Hotline { get; set; }

        [StringLength(300)]
        public string Zalo { get; set; }

        [StringLength(300)]
        public string Facebook { get; set; }

        [StringLength(300)]
        public string Youtube { get; set; }

        [StringLength(300)]
        public string Instagram { get; set; }

        [StringLength(300)]
        public string Website { get; set; }

        public string MetaTitle { get; set; }

        public string MetaDescription { get; set; }

        [StringLength(10)]
        public string Copyright { get; set; }
    }
}
