using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Churras.Models
{
    [Table("Churras")]
    public class Churras
    {
        public int Id { get; set; }

        [Required]
        public string Descricao { get; set; }

        public string Obs { get; set; }

        public ApplicationUser Organizador { get; set; }

        [Required]
        public string OrganizadorId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public Decimal ValorComBebida { get; set; }

        public Decimal ValorSemBebida { get; set; }
    }
}