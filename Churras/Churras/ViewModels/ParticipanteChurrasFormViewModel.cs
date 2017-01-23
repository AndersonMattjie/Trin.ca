using System;

namespace Churras.ViewModels
{
    public class ParticipanteChurrasFormViewModel
    {
        public bool IsPago { get; set; }
        public bool ComBebida { get; set; }
        public Decimal ValorContribuicao { get; set; }
        public int churrasId { get; set; }
    }
}