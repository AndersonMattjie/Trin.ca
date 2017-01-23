using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Churras.Models
{
    public class ParticipanteChurrasco
    {
        public Churrasco Churrasco { get; set; }
        public ApplicationUser Participante { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ChurrascoId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string ParticipanteId { get; set; }
    }
}