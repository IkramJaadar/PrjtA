using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PrjtA.Controllers
{
    public class RendezVousController : Controller
    {
        public ApplicationContext db;
        public RendezVousController(ApplicationContext db)
        {
            this.db = db;
        }
      
        public IActionResult Annuler(int? Id)
        {
            if (Id == null)
            {
                TempData["AlertError"] = true;
                TempData["AlertMessage"] = "Entrez un numéro";
                return RedirectToAction("List", "Client");

            }
            var rd = db.RendezVous.Include(p => p.payement).Where(r => r.Id == Id).FirstOrDefault();
            if (rd == null)
            {
                TempData["AlertError"] = true;
                TempData["AlertMessage"] = "Pas de rendez vous";
                return RedirectToAction("List", "Client");

            }


            rd.Etat = "Annulé";
            db.SaveChanges();
            TempData["AlertError"] = false;
            TempData["AlertMessage"] = "Bien Annulé";
            return RedirectToAction("Details", "Client", new
            {
                Id = rd.payement.ClientId
            });
        }
        public IActionResult Valider(int? Id)
        {
            if (Id == null)
            {
                TempData["AlertError"] = true;
                TempData["AlertMessage"] = "Entrez un numéro";
                return RedirectToAction("List", "Client");
            }
            var rd = db.RendezVous.Include(p => p.payement).Where(r => r.Id == Id).FirstOrDefault();
            if (rd == null)
            {
                TempData["AlertError"] = true;
                TempData["AlertMessage"] = "Pas de rendez vous";
                return RedirectToAction("List", "Client");
            }

            rd.Etat = "Validé";
            db.SaveChanges();
            TempData["AlertError"] = false;
            TempData["AlertMessage"] = "Bien Validé";
            return RedirectToAction("Details", "Client", new
            {
                Id = rd.payement.ClientId
            });
        }
        public IActionResult Payement(int? Id)
        {
            if (Id == null)
            {
                TempData["AlertError"] = true;
                TempData["AlertMessage"] = "Entrez un numéro";
                return RedirectToAction("List", "Client");
            }
            var payement = db.Payments.FirstOrDefault(p => p.RendezVousId == Id);
            return View(payement);
        }
    }
}
