using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace api.Database
{
    public class filmeDatabase
    {
           Models.apidbContext ctx = new Models.apidbContext();
           public Models.TbFilme Inserir(Models.TbFilme f)
           {
               ctx.Add(f);
               ctx.SaveChanges();
               return f;
           }
           public List<Models.TbFilme> Consultar()
           {
               List<Models.TbFilme> fs = ctx.TbFilme.ToList();
               return fs;
           }
           public Models.TbFilme Alterar(Models.TbFilme filme)
           {
               Models.TbFilme atual = ctx.TbFilme.FirstOrDefault(x=>x.IdFilme==filme.IdFilme);
               atual.NmFilme = filme.NmFilme;
               atual.DsGenero = filme.DsGenero;
               atual.VlAvaliacao = filme.VlAvaliacao;
               atual.BtDisponivel = filme.BtDisponivel;
               atual.NrDuracao = filme.NrDuracao;
               atual.DtLancamento = filme.DtLancamento;
               ctx.SaveChanges();
               return atual;
           }
           public Models.TbFilme ConsultarPorId(int id)
           {
               Models.TbFilme fs = ctx.TbFilme.FirstOrDefault(x=>x.IdFilme == id);
               return fs;
           }
           public Models.TbFilme deletarPorId(int id)
           {
               Models.TbFilme fs = ctx.TbFilme.FirstOrDefault(x=>x.IdFilme == id);
               ctx.Remove(fs);
               ctx.SaveChanges();
               return fs;
           }
           public List<Models.TbFilme> filtro(string nome, string genero)
           {
               List<Models.TbFilme> fs = ctx.TbFilme.Where(x=>x.NmFilme.Contains(nome) && x.DsGenero == genero).ToList();
               return fs;
           }
    }
}