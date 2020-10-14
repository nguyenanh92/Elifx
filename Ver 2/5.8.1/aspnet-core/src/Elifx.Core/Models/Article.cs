using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Elifx.Authorization.Users;

namespace Elifx.Models
{
    public class Article : FullAuditedEntity<int>
    {
        [ForeignKey("Menu")]
        public int MenuID { get; set; }
        [ForeignKey("User")]
        public long AuthorID { get; set; }
        public string Title { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
        public bool IsHome { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual User User { get; set; }
    }
}
