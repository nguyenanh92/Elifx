namespace Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Article")]
    public partial class Article
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MenuID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AuthorID { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(10)]
        public string Title { get; set; }

        [StringLength(150)]
        public string Alias { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public string MetaTitle { get; set; }

        public string MetaDescription { get; set; }

        public string Image { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool IsStatus { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool IsHome { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "date")]
        public DateTime CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ModifyDate { get; set; }

        public virtual Menu Menu { get; set; }

        public virtual User User { get; set; }
    }
}
