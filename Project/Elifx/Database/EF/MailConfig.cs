namespace Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MailConfig")]
    public partial class MailConfig
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        public int? Port { get; set; }

        [StringLength(100)]
        public string Smtp { get; set; }
    }
}
