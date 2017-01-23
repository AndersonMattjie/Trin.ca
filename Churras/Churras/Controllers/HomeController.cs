using Churras.Models;
using Churras.ViewModels;
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



            var proximosChurras = _context.Churras
                .Include(c => c.Organizador)
                .Where(c => c.DateTime > DateTime.Now);

            var viewModel = new ChurrasViewModel()
            {
                UpcommingChurras = proximosChurras,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Proximos Churras"
            };

            return View("Index", viewModel);
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