using Database.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Dto
{
    public class UserDto
    {
        ElifxDbContext db = null;

        public UserDto()
        {
            db = new ElifxDbContext();
        }

        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public User GetById (string username)
        {
            return db.Users.FirstOrDefault(a => a.Username.ToLower() == username.ToLower());
        }
        public bool Login(string username, string password)
        {
            var result = db.Users.FirstOrDefault(a => a.Username == username && a.Password == password);
            if(result != null) return true;
            return false;
        }
    }
}
