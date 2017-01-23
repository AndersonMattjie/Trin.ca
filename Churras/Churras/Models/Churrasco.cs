using System;
using System.ComponentModel.DataAnnotations;

namespace Churras.Models
{
    public class Churrasco
    {
        public int Id { get; set; }

        [Required]
        public string Descricao { get; set; }

        public string Obs { get; set; }

        public ApplicationUser Organizador { get; set; }

        [Required]
        public int OrganizadorId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }
    }
}