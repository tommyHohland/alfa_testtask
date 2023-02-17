using alfa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST
{
    internal static class General
    {
        
        public static alfa_testEntities conn = new alfa_testEntities();
        public static int Login(string login, string password)
        {
            var user = conn.Users.Where(c => c.Login == login && c.Password == password).FirstOrDefault();
            if (user != null) return user.UserType;
            return -1;
        }
    }
}
