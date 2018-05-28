using FirstProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstProject.Controllers
{
    public class business
    {
        MDPEntities dc = new MDPEntities();
        public bool checkLogin(signin user)
        {
            var flag = from x in dc.Users.ToList() where (x.Username == user.username && x.Password == user.password) select x;
            if (flag.Count() == 1)
                return true;
            return false;
        }
    }
}