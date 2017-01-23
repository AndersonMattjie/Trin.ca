using System;
using System.ComponentModel.DataAnnotations;

namespace Churras.ViewModels
{
    public class ValorValido : ValidationAttribute
    {
        public override bool IsValid(object value)
        {

            Decimal valor = Convert.ToDecimal(value);

            return (valor > 0);
        }
    }
}