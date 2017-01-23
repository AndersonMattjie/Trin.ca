using System;
using System.ComponentModel.DataAnnotations;

namespace Churras.ViewModels
{
    public class ChurrasFormViewModel
    {
        [Required(ErrorMessage = "Pra que o churras tchê?")]
        public string Descricao { get; set; }
        public string Obs { get; set; }

        [Required(ErrorMessage = "Precisamos saber quando é o churras Tchê!")]
        [FutureDate]
        public string Date { get; set; }

        [Required(ErrorMessage = "Churras não é de graça!")]
        [ValorValido(ErrorMessage = "Churras não é de graça!")]
        public Decimal ValorComBebida { get; set; }

        [Required(ErrorMessage = "Churras não é de graça!")]
        [ValorValido(ErrorMessage = "Churras não é de graça!")]
        public Decimal ValorSemBebida { get; set; }
    }
}