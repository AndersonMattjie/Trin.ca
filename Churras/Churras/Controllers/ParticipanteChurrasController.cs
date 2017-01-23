using Churras.Models;
using Churras.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Churras.Controllers
{
    public class ParticipanteChurrasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParticipanteChurrasController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: ParticipanteChurras
        public ActionResult Participar(int churrasId)
        {
            var userId = User.Identity.GetUserId();
            if (_context.ParticipanteChurras.Any(p => p.ChurrasId == churrasId && p.ParticipanteId == userId))
            {
                ModelState.AddModelError(String.Empty, "Voce ja esta participando deste churras.");
                return RedirectToAction("Index", "Home");
            }

            var viewModel = new ParticipanteChurrasFormViewModel
            {
                churrasId = churrasId
            };
            return View("Create", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ParticiparChurras(ParticipanteChurrasFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", viewModel);
            }

            var participacao = new ParticipanteChurras
            {
                ParticipanteId = User.Identity.GetUserId(),
                ChurrasId = viewModel.churrasId,
                IsPago = viewModel.IsPago,
                ComBebida = viewModel.ComBebida
            };

            _context.ParticipanteChurras.Add(participacao);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}