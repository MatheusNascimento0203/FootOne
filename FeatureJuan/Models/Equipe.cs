using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FeatureJuan.Models
{
    public class Equipe
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EquipeId { get; set; }
        [Required(ErrorMessage = "Digite o nome da equipe")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite a quantidade de integrantes")]
        public int QuantidadeIntegrantes { get; set; }
        [Required(ErrorMessage = "Informe a divisão"), ForeignKey("DivisaoId")]
        public int DivisaoId { get; set; }


        public Divisao Divisao { get; set; }
    }
}