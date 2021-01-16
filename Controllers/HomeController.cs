using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Validation.Models;

namespace Validation.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View("Register",new Register() { BirthDate=DateTime.Now});
        }

        [HttpPost]
        public IActionResult Register(Register m)
        {
            if (string.IsNullOrEmpty(m.Name))
            {
                ModelState.AddModelError("Name", "İsim Zorunlu Alan");
            }

            if(string.IsNullOrEmpty(m.UserName))
            {
                ModelState.AddModelError("UserName", "Zorunlu Alan");
            }
            else
            {
                if (m.UserName.Length < 3)
                {
                    ModelState.AddModelError("UserName", "Kullanıcı Adı Minumum 3 Karakter");
                }
            }

            if (string.IsNullOrEmpty(m.Email))
            {
                ModelState.AddModelError("Email", "Email Zorunlu Alan");
            }
            else
            {
                if (!m.Email.Contains("@"))
                {
                    ModelState.AddModelError("Email", "Email düzgün girilmemiş");
                }
            }

            if (string.IsNullOrEmpty(m.Password))
            {
                ModelState.AddModelError("Password", "Parola Zorunlu Alan");
            }
            else
            {
                if (m.Password.Length < 8)
                {
                    ModelState.AddModelError("Password", "Parola minumum 8 karakter olmalı");
                }
            }

            if (!m.Accepted)
            {
                ModelState.AddModelError("Accepted", "Şartları Kabul Etmelisiniz");
            }




            if (ModelState.IsValid)
            {
                return View("Completed", m);
            }

            return View(m);

          
        }


    }
}
