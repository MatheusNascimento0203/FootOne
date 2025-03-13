using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeatureJuan.Models
{
    public class Divisao
    {
        [Key]
        public int DivisaoId { get; set; }

        public string Nome { get; set; }

        public ICollection<Equipe> Equipes { get; set; }

    }
}