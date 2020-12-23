using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace api.Models.Response
{
    public class filmeResponse
    {
        public int id { get; set; }
        public string filme { get; set; }
        public string genero { get; set; }
        public decimal? avaliacao { get; set; }
        public bool disponivel { get; set; }
        public int? duracao { get; set; }
        public DateTime lancamento { get; set; }
    }
}
