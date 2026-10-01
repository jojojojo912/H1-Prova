using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CascaApi.Validations
{
    public sealed class CpfValidoAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var cpf = value?.ToString();
            if (string.IsNullOrWhiteSpace(cpf))
                return new ValidationResult("CPF e obrigatorio.");

            cpf = Regex.Replace(cpf, @"\D", string.Empty);
            if (cpf.Length != 11 || cpf.Distinct().Count() == 1)
                return new ValidationResult("Informe um CPF valido.");

            for (var i = 9; i < 11; i++)
            {
                var soma = 0;
                for (var j = 0; j < i; j++)
                    soma += (cpf[j] - '0') * ((i + 1) - j);

                var digito = (soma * 10) % 11;
                if (digito == 10) digito = 0;
                if (digito != cpf[i] - '0')
                    return new ValidationResult("Informe um CPF valido.");
            }

            return ValidationResult.Success;
        }
    }
}
