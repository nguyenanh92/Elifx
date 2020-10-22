using System.Linq;
using DataLibrary.Database;

namespace DataLibrary.Security
{
    public class CheckLogin
    {
        public static int CheckUserLogin(string username, string password, bool remember)
        {
            using (var db = new MyDbDataContext())
            {
                CurrentSession.ClearAll();
                string pashPassWord = Password.HashPassword(password);
                User checkUser = db.Users.FirstOrDefault(u => u.Username == username && u.Password == pashPassWord);
                if (checkUser != null)
                {
                    if (checkUser.IsActive)
                    {
                     
                        return 1;
                    }
                    return 2;
                }
            }
            return 3;
        }

        public static User GetUser(string username)
        {
            using (var db = new MyDbDataContext())
            {
                
               return  db.Users.SingleOrDefault(u => u.Username == username  );
                 
            }
        }
    }
}