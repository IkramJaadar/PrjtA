using Microsoft.AspNetCore.Mvc;
using PrjtA.Models;

namespace PrjtA.Controllers
{
    public class SlidersController : Controller
    {
        public ApplicationContext db;
        public SlidersController(ApplicationContext db)
        {
            this.db = db;
        }
        public IActionResult List()
        {
            List<Sliders> lst = db.Sliders.ToList();
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
        public IActionResult Create(Sliders sliders, IFormFile Fichier1)
        {
            if (ModelState.IsValid)
            {
                db.Sliders.Add(sliders);
                    db.SaveChanges();

                string[] allowedExtentions = { ".png", ".jpeg", ".jpg" };
                string fileExtention = Path.GetExtension(Fichier1.FileName).ToLower();
                if (allowedExtentions.Contains(fileExtention))
                {
                    //si on veut enregister dans un fichier qui s'appele files donc /files
                    //slide-1-5448584.jpg
                    string newName ="slide-" +sliders.Num + "-" +Guid.NewGuid() + fileExtention;
                    string pathName = Path.Combine("wwwroot", "DATA/IMG/SLIDER", newName);

                    //Verfier Si Le Dossier n'Exist pas Cree un Nvl Dir 
                    string dir = Path.Combine("wwwroot", "DATA/IMG/SLIDER");
                    // Create Directory IF Not Exist
                    if (!Directory.Exists(dir))
                        System.IO.Directory.CreateDirectory(dir);
                    /**********************/

                    using (FileStream stream = System.IO.File.Create(pathName))
                    {
                        Fichier1.CopyTo(stream);
                    }

                    
                    TempData["AlertError"] = false;
                    TempData["AlertMessage"] = "Bien Ajouté";

                    return RedirectToAction("List");
                }            
            }
            TempData["AlertError"] = true;
                TempData["AlertMessage"] = "Erreur d'Ajout";
            return View(sliders);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            var sliders = db.Sliders.Find(id);
            if ( sliders == null)
                return RedirectToAction("List");

            return View(sliders);
        }
        [HttpPost]
        public IActionResult Edit(Sliders sliders, IFormFile Fichier1)
        {
            if (ModelState.IsValid)
            {

                string[] allowedExtentions = { ".png", ".jpeg", ".jpg" };
                string fileExtention = Path.GetExtension(Fichier1.FileName).ToLower();
                if (allowedExtentions.Contains(fileExtention))
                {
                    //si on veut enregister dans un fichier qui s'appele files donc /files
                    //slide-1-5448584.jpg
                    string newName = "slide-" + sliders.Num + "-" + Guid.NewGuid() + fileExtention;
                    string pathName = Path.Combine("wwwroot", "DATA/IMG/SLIDER", newName);

                    //Verfier Si Le Dossier n'Exist pas Cree un Nvl Dir 
                    string dir = Path.Combine("wwwroot", "DATA/IMG/SLIDER");
                    // Create Directory IF Not Exist
                    if (!Directory.Exists(dir))
                        System.IO.Directory.CreateDirectory(dir);
                    /**********************/

                    using (FileStream stream = System.IO.File.Create(pathName))
                    {
                        Fichier1.CopyTo(stream);
                    }
                }

                    db.Update(sliders);
                    db.SaveChanges();
                    TempData["AlertError"] = false;
                    TempData["AlertMessage"] = "Bien modifié";

                    return RedirectToAction("List");
                }

                TempData["AlertError"] = true;
                TempData["AlertMessage"] = "Erreur de modification";
            
            return View(sliders);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["AlertError"] = true;
                TempData["AlertMessage"] = "Entrez un numéro";

                return RedirectToAction("List");
            }
            var sliders = db.Sliders.Find(id);
            if (sliders == null)
            {
                TempData["AlertError"] = true;
                TempData["AlertMessage"] = "Service non trouvé";

                return RedirectToAction("List");
            }

            db.Sliders.Remove(sliders);
            db.SaveChanges();
            TempData["AlertError"] = false;
            TempData["AlertMessage"] = "Bien supprimé";

            return RedirectToAction("List");
        }

    }
}
