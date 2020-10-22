using System.Collections.Generic;
using DataLibrary.Database;
 
namespace PCar.Models
{
    public class DetailArticle
    {
        public Article Article { get; set; }
        public List<Article> Articles { get; set; }
    }
}