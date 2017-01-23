using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Churras.Models
{
    [Table("ParticipanteChurras")]
    public class ParticipanteChurras
    {
        public Churras Churras { get; set; }
        public ApplicationUser Participante { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ChurrasId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string ParticipanteId { get; set; }

        [Required]
        public Decimal ValorContribuicao { get; set; }

        [Required]
        public bool IsPago { get; set; }

        [Required]
        public bool ComBebida { get; set; }

    }
}