using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrjtA.Models;

namespace PrjtA.Controllers
{
    public class ClientController : Controller
    {
        public ApplicationContext db;
        public ClientController(ApplicationContext db)
        {
            this.db = db;   
        }
        public IActionResult List()
        {
            List<Client> cl = db.Clients.ToList();
            return View(cl);
        }
        public IActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("List");
            }
            AlertModel? alertModel = null;
            if (TempData["AlertError"] != null && TempData["AlertMessage"] != null)
                alertModel = new AlertModel()
                {
                    isError = (Boolean)TempData["AlertError"],
                    Message = (string)TempData["AlertMessage"]
                };
            ViewBag.AlertMessage = alertModel;
            List<RendezVous> rv = db.RendezVous.Include(p => p.payement).Include(s=>s.services).Where(p=>p.payement.ClientId==Id).ToList();
            return View(rv);
        }
    }
}
