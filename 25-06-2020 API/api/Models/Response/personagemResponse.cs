using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace api.Models.Response
{
    public class personagemResponse
    {
        public int id { get; set; }
        public string personagem { get; set; }
        public int filme { get; set; }
        public int ator { get; set; }
    }
}