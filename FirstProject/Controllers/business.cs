using FirstProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstProject.Controllers
{
    public class business
    {
        DataEntities dc = new DataEntities();
        public bool checkLogin(signin user)
        {
            var flag = from x in dc.UserDetails.ToList() where (x.username == user.username && x.password == user.password) select x;
            if (flag.Count() == 1)
                return true;
            return false;
        }
    }
}