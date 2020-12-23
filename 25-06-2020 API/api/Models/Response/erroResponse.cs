using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace api.Models.Response
{
    public class erroResponse
    {
        public erroResponse(Exception ex,int codigo1)
        {
            codigo = codigo1;
            erro = ex.Message;
        } 
        public int codigo { get; set; }  
        public string erro { get; set; }
        
    }

}