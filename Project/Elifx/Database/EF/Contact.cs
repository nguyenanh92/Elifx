namespace Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contact")]
    public partial class Contact
    {
        public int ID { get; set; }

        [StringLength(150)]
        public string FirstName { get; set; }

        [StringLength(150)]
        public string LastName { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(150)]
        public string Address { get; set; }

        [StringLength(150)]
        public string Phone { get; set; }

        public int Type { get; set; }

        [StringLength(300)]
        public string Message { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreateDate { get; set; }
    }
}
