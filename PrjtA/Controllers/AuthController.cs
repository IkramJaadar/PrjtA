
using Microsoft.AspNetCore.Mvc;
using PrjtA.Models;
using System.Data;


namespace PrjtA.Controllers
{
    public class AuthController : Controller
    {

        public ApplicationContext db;
        public AuthController(ApplicationContext db)
        {
            this.db = db;
        }
        public IActionResult Login()
        {
            //Get Cookies
            string? id = HttpContext.Request.Cookies["id"];
            string? fullname = HttpContext.Request.Cookies["fullname"];
            //Verify if Cookies Exist
            if (id != null && fullname != null)
            {
                //Set Sessions Values from Cookies
                HttpContext.Session.SetString("id", id);
                HttpContext.Session.SetString("fullname", fullname);

                //Automaticly Redirect to Home Page, if Cookies are Set
                return RedirectToAction("Index", "Home");
            }
            //If No Cookies Found show Login Page
            return View();
        }
        [HttpPost]
        public IActionResult Login(Coiffeur coiffeur)
        {
            var lg = db.Coiffeurs.Where(c => c.Email == coiffeur.Email && c.Password == coiffeur.Password).FirstOrDefault();
            if (lg != null )// Si l'utilisateur est trouvé dans la base de données
            {
                HttpContext.Session.SetInt32("Id", lg.Id);
                HttpContext.Session.SetString("fullname", lg.Nom + " " + lg.Prenom);
                //Cookies
                if (coiffeur.RememberMe == true)
                {
                    CookieOptions co = new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(30)
                    };
                    Response.Cookies.Append("id",  coiffeur.Id.ToString(), co);
                   
                    Response.Cookies.Append("fullname", coiffeur.Nom + " " + coiffeur.Prenom, co);
                }
                return RedirectToAction("Index", "Home");

            }
            ModelState.AddModelError("", "Les informations sont incorrectes");
            return View(coiffeur);
        }  
       
    }
    }

    
    














