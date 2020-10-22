using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Common
{
    [Serializable]
    public class UserLogin
    {
        public int ID { get; set; }
        public string UserName { get; set; }
    }
}
