using Churras.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Churras.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var proximosChurras = _context.Churrascos
                .Include(c => c.Organizador)
                .Where(c => c.DateTime > DateTime.Now);

            return View(proximosChurras);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}