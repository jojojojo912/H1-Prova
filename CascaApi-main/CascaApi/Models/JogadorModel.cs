using System.ComponentModel.DataAnnotations;
using CascaApi.Validations;

namespace CascaApi.Models
{
    public class JogadorModel
    {
        [Required(ErrorMessage = "Nome e obrigatorio.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nome deve ter entre 3 e 50 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "CPF e obrigatorio.")]
        [CpfValido]
        public string Cpf { get; set; } = string.Empty;

        [Required(ErrorMessage = "Posicao e obrigatoria.")]
        [RegularExpression("^(GL|ZA|LD|LE|VO|MD|AT)$", ErrorMessage = "Posicao invalida. Use GL, ZA, LD, LE, VO, MD ou AT.")]
        public string Posicao { get; set; } = string.Empty;

        public bool Aprovado { get; set; } = false;
    }
}
