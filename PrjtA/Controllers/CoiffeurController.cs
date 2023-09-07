using Microsoft.AspNetCore.Mvc;
using PrjtA.Models;

namespace PrjtA.Controllers
{
    public class CoiffeurController : Controller
    {
        public ApplicationContext db;
        public CoiffeurController(ApplicationContext db)
        {
            this.db = db;
        }
     public IActionResult Profil()
        {
            
            int ?id=HttpContext.Session.GetInt32("Id");
            var coif = db.Coiffeurs.Where(c => c.Id == id).FirstOrDefault();
            if(coif != null) {
                return View(coif);
            }
         return RedirectToAction("Index","Home");
        }
        [HttpPost]
        public IActionResult ProfilePwd(Coiffeur coiffeur)
        {
            var usr = db.Coiffeurs.Find(coiffeur.Id);
            if (usr != null)
            {
                if (usr.Password==coiffeur.Password)
                {
                    if (coiffeur.NouvPass.Trim() == coiffeur.ConfPass.Trim() && coiffeur.NouvPass.Trim() != "")
                    {
                        usr.Password =     coiffeur.NouvPass;
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("Profil", "Coiffeur");
        }
    }
}
