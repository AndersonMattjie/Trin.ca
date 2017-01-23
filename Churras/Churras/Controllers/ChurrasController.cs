using Churras.Models;
using Churras.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
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

        public ActionResult Detalhes(int churrasId)
        {
            var detalhes = new ChurrasDetalhesViewModel(churrasId, _context);

            return View("Detalhes", detalhes);
        }

        public ActionResult MeusChurras()
        {
            var userId = User.Identity.GetUserId();
            var churras = _context.Churras
                .Where(c => c.OrganizadorId == userId)
                .Include(c => c.Organizador).ToList();

            var viewModel = new ChurrasViewModel()
            {
                UpcommingChurras = churras,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Churras que eu organizei"
            };

            return View("MeusChurras", viewModel);
        }

        public ActionResult ChurrasQueEuVou()
        {
            var userId = User.Identity.GetUserId();
            var churras = _context.ParticipanteChurras
                .Where(c => c.ParticipanteId == userId)
                .Select(c => c.Churras)
                .Include(c => c.Organizador).ToList();

            var viewModel = new ChurrasViewModel()
            {
                UpcommingChurras = churras,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Churras que eu Vou"
            };

            return View("ChurrasQueEuVou", viewModel);
        }


    }
}