using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace api.Models.Response
{
    public class atorResponse
    {
        public int id { get; set; }
        public string nome { get; set; }
        public decimal altura { get; set; }
        public DateTime nascimento { get; set; }
    }
}