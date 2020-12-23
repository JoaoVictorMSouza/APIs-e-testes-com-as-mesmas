using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace api.Database
{
    public class atorDatabase
    {
        Models.apidbContext ctx = new Models.apidbContext();
        public Models.TbAtor inserirAtor(Models.TbAtor ator)
        {
            ctx.Add(ator);
            ctx.SaveChanges();
            return ator;
        }
        public Models.TbAtor consultarAtor(string nome)
        {
            Models.TbAtor ator = ctx.TbAtor.FirstOrDefault(x=>x.NmAtor.Contains(nome));
            return ator;
        }
        public Models.TbAtor alterarAtor(Models.TbAtor a)
        {
            Models.TbAtor atual = ctx.TbAtor.FirstOrDefault(x=>x.IdAtor==a.IdAtor);
            if(atual == null) throw new ArgumentException("Não encontrado");
            atual.NmAtor = a.NmAtor;
            atual.VlAltura = a.VlAltura;
            atual.DtNascimento = a.DtNascimento;
            ctx.SaveChanges();
            return atual;
        }
        public Models.TbAtor consultarAtorID(int id)
        {
            Models.TbAtor atual = ctx.TbAtor.FirstOrDefault(x=>x.IdAtor==id);
            return atual;
        }
        public Models.TbAtor deletarAtor(int id)
        {
            Models.TbAtor atual = ctx.TbAtor.FirstOrDefault(x=>x.IdAtor==id);
            if(atual == null) throw new ArgumentException("Não encontrado");
            ctx.Remove(atual);
            ctx.SaveChanges();
            return atual;
        }
    }
}