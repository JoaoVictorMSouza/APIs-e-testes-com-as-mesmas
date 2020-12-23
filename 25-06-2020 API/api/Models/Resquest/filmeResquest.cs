using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace api.Models.Resquest
{
    public class filmeResquest1
    {
        public string filme { get; set; }
        public string genero { get; set; }
        public decimal avaliacao { get; set; }
        public bool disponivel { get; set; }
        public int? duracao { get; set; }
        public DateTime lancamento { get; set; }
    }
}   