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
        public string DivisaoId { get; set; }

        public string Nome { get; set; }

    }
}