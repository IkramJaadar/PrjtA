using Microsoft.AspNetCore.Mvc;
using PrjtA.Models;
using System.Diagnostics;

namespace PrjtA.Controllers
{
    public class HomeController : Controller
    {
       
        public ApplicationContext db;
        public HomeController(ApplicationContext db)
        {
            this.db = db;
        }
        

        public IActionResult Index()
        {

            //Cards Statistics
            ViewBag.NbrServices = db.Services.Where(x => x.isActive).Count();

            ViewBag.ClientsCount = db.Clients.Count();

            ViewBag.NbrRendezvous = db.RendezVous.Count();

            ViewBag.NbrRendezvousEncours = db.RendezVous.Where(x => x.Etat == "EnCours").Count();

            ViewBag.NbrRendezvousValide = db.RendezVous.Where(x => x.Etat == "Validé").Count();
            ViewBag.NbrRendezvousAnnule = db.RendezVous.Where(x => x.Etat == "Annulé").Count();

            ViewBag.CAannee = db.Payments.Where(p => p.DatePayement.Year == DateTime.Now.Year).Sum(p => p.Prix);
            ViewBag.CAtotal = db.Payments.Sum(p => p.Prix);
            return View();   
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}