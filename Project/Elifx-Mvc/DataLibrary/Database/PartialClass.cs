using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// ReSharper disable CheckNamespace
namespace DataLibrary.Database
// ReSharper restore CheckNamespace
{

    public partial class User
    {
        [NotMapped]
        public string ConfirmPassword { get; set; }
    }
    public partial class Article
    {
        [NotMapped]
        public string MenuAlias { get; set; }
     }

}
