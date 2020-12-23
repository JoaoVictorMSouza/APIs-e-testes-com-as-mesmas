using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace api.Models.Resquest
{
    public class diretorRequest
    {
        public int filme { get; set; }
        public string diretor { get; set; }
        public DateTime nascimento { get; set; }
    }
}