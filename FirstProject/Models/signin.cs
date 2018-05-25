using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace FirstProject.Models
{
    public class signin
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }

    }
}