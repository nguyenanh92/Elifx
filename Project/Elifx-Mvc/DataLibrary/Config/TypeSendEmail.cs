using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace DataLibrary.Config
{
    public class TypeSendEmail
    {
        public static int Contact = 1;
 


        public static List<ListItem> ListTypeSendEmail()
        {
            var listTypeSendEmail = new List<ListItem>
            {
                new ListItem
                {
                    Value = Contact.ToString(),
                    Text = "Liên hệ",
                } 
            };

            return listTypeSendEmail;
        }
    }
}