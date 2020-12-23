using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace api.Utils
{
    public class filmeConversor
    {
        public Models.TbFilme conversorDeRequest(Models.Resquest.filmeResquest1 f)
        {
            Models.TbFilme a = new Models.TbFilme();
            a.NmFilme = f.filme;
            a.DsGenero = f.genero;
            a.VlAvaliacao = f.avaliacao;
            a.BtDisponivel = f.disponivel;
            a.NrDuracao = f.duracao;
            a.DtLancamento = f.lancamento;

            return a;
        }
        public Models.TbFilme conversorDeRequest2(int id,Models.Resquest.filmeResquest1 f)
        {
            Models.TbFilme a = new Models.TbFilme();
            a.IdFilme = id;
            a.NmFilme = f.filme;
            a.DsGenero = f.genero;
            a.VlAvaliacao = f.avaliacao;
            a.BtDisponivel = f.disponivel;
            a.NrDuracao = f.duracao;
            a.DtLancamento = f.lancamento;

            return a;
        }
        






        public Models.Response.filmeResponse conversorDeResponse(Models.TbFilme f)
        {
            Models.Response.filmeResponse a = new Models.Response.filmeResponse();
            a.id = f.IdFilme;
            a.filme = f.NmFilme ;
            a.genero = f.DsGenero ;
            a.avaliacao = f.VlAvaliacao ;
            a.disponivel = f.BtDisponivel ;
            a.duracao = f.NrDuracao;
            a.lancamento = f.DtLancamento;

            return a;
        }
         
        public List<Models.Response.filmeResponse> conversorDeResponse2(List<Models.TbFilme>  filmes)
        {
            List<Models.Response.filmeResponse> te = 
            filmes.Select(x=>new Models.Response.filmeResponse()
            {
                id = x.IdFilme,
                filme = x.NmFilme,
                genero = x.DsGenero,
                avaliacao = x.VlAvaliacao,
                disponivel = x.BtDisponivel,
                duracao = x.NrDuracao,
                lancamento = x.DtLancamento
            }).ToList();
            return te;
        }
    
    }
}