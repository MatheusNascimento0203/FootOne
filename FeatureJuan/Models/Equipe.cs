using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FeatureJuan.Models
{
    public class Equipe
    {
        [Key]
        public string EquipeId { get; set; }
        [Required(ErrorMessage = "Digite o nome da equipe")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite a quantidade de integrantes")]
        public int QuantidadeIntegrantes { get; set; }
        [Required(ErrorMessage = "Informe a divisão")]
        public string DivisaoId { get; set; }
        [ValidateNever]
        public Divisao Divisao { get; set; }
    }
}