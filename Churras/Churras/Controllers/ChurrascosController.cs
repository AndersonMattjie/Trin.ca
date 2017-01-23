using Churras.Models;
using Churras.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace Churras.Controllers
{
    public class ChurrascosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChurrascosController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Churrascos
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new ChurrascoFormViewModel();

            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(ChurrascoFormViewModel viewModel)
        {


            if (!ModelState.IsValid)
            {
                return View("Create", viewModel);
            }

            var churrasco = new Churrasco
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
                _context.Churrascos.Add(churrasco);
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