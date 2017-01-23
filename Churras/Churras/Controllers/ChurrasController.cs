using Churras.Models;
using Churras.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace Churras.Controllers
{
    public class ChurrasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChurrasController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Churras
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new ChurrasFormViewModel();

            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(ChurrasFormViewModel viewModel)
        {


            if (!ModelState.IsValid)
            {
                return View("Create", viewModel);
            }

            var Churras = new Models.Churras
            {
                OrganizadorId = User.Identity.GetUserId(),
                ValorComBebida = viewModel.ValorComBebida,
                ValorSemBebida = viewModel.ValorSemBebida,
                Descricao = viewModel.Descricao,
                Obs = viewModel.Obs,
                DateTime = DateTime.Parse(string.Format("{0}", viewModel.Date))
            };

            try
            {
                _context.Churras.Add(Churras);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            return RedirectToAction("Index", "Home");
        }
    }
}