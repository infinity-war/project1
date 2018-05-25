using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstProject.Models
{
    public class signup
    {
        public string username { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public Nullable<int> mobileNo { get; set; }
        public string password { get; set; }
        public string rePassword { get; set; }
    }
}