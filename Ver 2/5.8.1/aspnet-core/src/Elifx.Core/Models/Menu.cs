using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace Elifx.Models
{
    public class Menu : FullAuditedEntity<int>
    {
        public string NameMenu { get; set; }
        [ForeignKey("Parent")]
        public int? ParentId { get; set; }
        public string Alias { get; set; }
        public int TypeMenu { get; set; }
        public bool Status { get; set; }
        public bool IsHome { get; set; }

        public virtual Menu Parent { get; set; }

    }
}
