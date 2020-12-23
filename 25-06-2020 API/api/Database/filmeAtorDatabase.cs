using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace api.Database
{
    public class filmeAtorDatabase
    {
        Models.apidbContext ctx = new Models.apidbContext();
        public Models.TbFilmeAtor inserirPersonagem(Models.TbFilmeAtor perso)
        {
            ctx.Add(perso);
            ctx.SaveChanges();
            return perso;
        }
        public List<Models.TbFilmeAtor>  consultarPersonagemPorFilme(int idFilme)
        {
            List<Models.TbFilmeAtor>  perso = ctx.TbFilmeAtor.Where(x=>x.IdFilme == idFilme).ToList();
            return perso;
        }
        public Models.TbFilmeAtor AlterarPersonagemPorFilmeEAtor(Models.TbFilmeAtor a)
        {
            Models.TbFilmeAtor atual = ctx.TbFilmeAtor.FirstOrDefault(x=>x.IdFilme==a.IdFilme && x.IdFilmeAtor==a.IdFilmeAtor);
            atual.NmPersonagem = a.NmPersonagem;
            atual.IdFilme = a.IdFilme;
            atual.IdAtor = a.IdAtor;
            ctx.SaveChanges();
            return atual;
        }
        public Models.TbFilmeAtor  consultarPersonagemPorid(int idperso)
        {
            Models.TbFilmeAtor  perso = ctx.TbFilmeAtor.FirstOrDefault(x=>x.IdFilmeAtor == idperso);
            return perso;
        }
        public Models.TbFilmeAtor  consultarPersonagemPorIDfilmeEperso(int idfilme, int idperso)
        {
            Models.TbFilmeAtor  perso = ctx.TbFilmeAtor.FirstOrDefault(x=>x.IdFilme == idfilme && x.IdFilmeAtor == idperso);
            return perso;
        }
        public Models.TbFilmeAtor deletarPersonagemPorIDfilmeEperso(int idfilme, int idperso)
        {
            Models.TbFilmeAtor fs = ctx.TbFilmeAtor.FirstOrDefault(x=>x.IdFilme == idfilme && x.IdFilmeAtor == idperso);
            ctx.Remove(fs);
            ctx.SaveChanges();
            return fs;
        }
    }
}