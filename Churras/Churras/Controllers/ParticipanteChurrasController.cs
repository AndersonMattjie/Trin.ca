using Churras.Dtos;
using Churras.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Http;

namespace Churras.Controllers
{
    [Authorize]
    public class ParticipanteChurrasController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public ParticipanteChurrasController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Participar(ParticipacaoDto dto)
        {
            var userId = User.Identity.GetUserId();
            if (_context.ParticipanteChurras.Any(p => p.ParticipanteId == userId && p.ChurrasId == dto.ChurrasId))
            {
                return BadRequest("Ja esta participando do churras tche!");
            }

            var participacao = new ParticipanteChurras
            {
                ChurrasId = dto.ChurrasId,
                ParticipanteId = userId
            };

            try
            {
                _context.ParticipanteChurras.Add(participacao);

                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            return Ok();

        }
    }
}