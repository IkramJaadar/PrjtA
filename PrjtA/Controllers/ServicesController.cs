using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PrjtA.Models;
namespace PrjtA.Controllers
{
    public class ServicesController : Controller
    {
        public ApplicationContext db;
        public ServicesController(ApplicationContext db)
        {
            this.db = db;
        }
        public IActionResult List()
        {
            List<Service> lst = db.Services.ToList();
            // initialiser 
            AlertModel? alertModel = null;
            if (TempData["AlertError"] != null && TempData["AlertMessage"] != null)
                alertModel = new AlertModel()
                {
                    isError = (Boolean)TempData["AlertError"],
                    Message = (string)TempData["AlertMessage"]
                };
            ViewBag.AlertMessage = alertModel;
            return View(lst);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Service service)
        {
            if (ModelState.IsValid)
            {
                db.Services.Add(service);
                db.SaveChanges();
                TempData["AlertError"] = false;
                TempData["AlertMessage"] = "Bien Ajouté";

                return RedirectToAction("List");
            }

            TempData["AlertError"] = true;
            TempData["AlertMessage"] = "Erreur d'Ajout";

            return View(service);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            var service = db.Services.Find(id);
            if (service == null)
                return RedirectToAction("List");

            return View(service);
        }
        [HttpPost]
        public IActionResult Edit(Service service)
        {
            if (ModelState.IsValid)
            {
                db.Update(service);
                db.SaveChanges();
                TempData["AlertError"] = false;
                TempData["AlertMessage"] = "Bien modifié";

                return RedirectToAction("List");
            }

            TempData["AlertError"] = true;
            TempData["AlertMessage"] = "Erreur de modification";
            return View(service);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["AlertError"] = true;
                TempData["AlertMessage"] = "Entrez un numéro";

                return RedirectToAction("List");
            }
            var service = db.Services.Find(id);
            if (service == null)
            {
                TempData["AlertError"] = true;
                TempData["AlertMessage"] = "Service non trouvé";

                return RedirectToAction("List");
            }
          
            db.Services.Remove(service);
            db.SaveChanges();
            TempData["AlertError"] = false;
            TempData["AlertMessage"] = "Bien supprimé";

            return RedirectToAction("List");
        }
        public IActionResult Activer(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            var service = db.Services.Find(id);
            if (service == null)
                return RedirectToAction("List");
            service.isActive = true;
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Desactiver(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            var service = db.Services.Find(id);
            if (service == null)
                return RedirectToAction("List");
            service.isActive = false;
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}

