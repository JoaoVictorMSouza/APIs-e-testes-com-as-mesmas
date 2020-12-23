using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace api.Database
{
    public class diretorDatabase
    {
        Models.apidbContext ctx = new Models.apidbContext();
        public Models.TbDiretor inserirDiretor(Models.TbDiretor diretor)
        {
            ctx.Add(diretor);
            ctx.SaveChanges();
            return diretor;
        }
        public Models.TbDiretor consultarDiretor(string nome)
        {
            Models.TbDiretor diretor = ctx.TbDiretor.FirstOrDefault(x=>x.NmDiretor.Contains(nome));
            return diretor;
        }
        public Models.TbDiretor alterarDiretor(Models.TbDiretor diretor)
        {
            Models.TbDiretor atual = ctx.TbDiretor.FirstOrDefault(x=>x.IdDiretor==diretor.IdDiretor);
            atual.NmDiretor = diretor.NmDiretor;
            atual.IdFilme = diretor.IdFilme;
            atual.DtNascimento = diretor.DtNascimento;
            ctx.SaveChanges();
            return atual;
        }
        public Models.TbDiretor consultarDiretorID(int id)
        {
            Models.TbDiretor diretor = ctx.TbDiretor.FirstOrDefault(x=>x.IdDiretor == id);
            if(diretor == null) throw new ArgumentException("Não encontrado");
            return diretor;
        }
        public Models.TbDiretor deletarDiretor(int id)
        {
            Models.TbDiretor atual = ctx.TbDiretor.FirstOrDefault(x=>x.IdDiretor==id);
            ctx.Remove(atual);
            ctx.SaveChanges();
            return atual;
        }
    }
}