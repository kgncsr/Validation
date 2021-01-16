using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Validation.Models
{
    public class Register
    {
        public string Name { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Parola Tekrar Alanı Yanlış")]
        [Display(Name = "Password Again")]
        public string RePassword { get; set; }

        [UIHint("Date")]
        public DateTime BirthDate { get; set; }

        public bool Accepted{ get; set; }
    }
}
