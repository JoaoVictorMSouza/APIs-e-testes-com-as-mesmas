using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace api.Utils
{
    public class diretorConversor
    {
        public Models.TbDiretor conversorDeRequest(Models.Resquest.diretorRequest d)
        {
            Models.TbDiretor a = new Models.TbDiretor();
            a.IdFilme = d.filme;
            a.NmDiretor = d.diretor;
            a.DtNascimento = d.nascimento;

            return a;
        }
        public Models.TbDiretor conversorDeRequest2(int id,Models.Resquest.diretorRequest d)
        {
            Models.TbDiretor a = new Models.TbDiretor();
            a.IdDiretor = id;
            a.IdFilme = d.filme;
            a.NmDiretor = d.diretor;
            a.DtNascimento = d.nascimento;

            return a;
        }
        public Models.Response.diretorResponse conversorDeResponse(Models.TbDiretor d)
        {
            Models.Response.diretorResponse a = new Models.Response.diretorResponse();
            a.id = d.IdDiretor;
            a.filme = d.IdFilme;
            a.diretor = d.NmDiretor;
            a.nascimento = d.DtNascimento;

            return a;
        }
        
    }
}