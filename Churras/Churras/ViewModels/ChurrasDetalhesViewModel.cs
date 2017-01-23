using Churras.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Churras.ViewModels
{
    public class ChurrasDetalhesViewModel
    {
        public Models.Churras Churras { get; set; }
        public Decimal ValorASerArrecadado
        {
            get { return Participantes.Select(p => p.ValorContribuicao).Sum(); }
        }

        public Decimal ValorJaPago
        {
            get { return Participantes.Where(p => p.IsPago).Select(p => p.ValorContribuicao).Sum(); }
        }


        public ICollection<ParticipanteChurras> Participantes { get; private set; }

        public ChurrasDetalhesViewModel()
        {
            Participantes = new Collection<ParticipanteChurras>();
        }

        public ChurrasDetalhesViewModel(int churrasId, ApplicationDbContext _context)
        {
            var churras = _context.Churras.Single(c => c.Id == churrasId);
            var participantes = _context.ParticipanteChurras.Where(p => p.ChurrasId == churrasId).ToList();

            Participantes = participantes;
            Churras = churras;


        }

        public int TotalParticipantes
        {
            get
            {
                if (Participantes != null)
                    return Participantes.Count;
                return 0;
            }
        }


        public int TotalBebuns
        {
            get
            {
                if (Participantes != null)
                    return Participantes.Count(p => p.ComBebida);
                return 0;
            }
        }

        public int TotalSaudaveis
        {
            get
            {
                if (Participantes != null)
                    return Participantes.Count(p => !p.ComBebida);
                return 0;
            }
        }
    }
}