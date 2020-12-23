using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace api.Utils
{
    public class personagemConversor
    {
        public Models.TbFilmeAtor conversorDeRequest(int filmeid,Models.Resquest.personagemRequest a)
        {
            Models.TbFilmeAtor b = new Models.TbFilmeAtor();
            b.NmPersonagem = a.personagem;
            b.IdFilme = filmeid;
            b.IdAtor = a.ator;

            return b;
        }
        public Models.Response.personagemResponse conversorDeResponse(Models.TbFilmeAtor a)
        {
            Models.Response.personagemResponse b = new Models.Response.personagemResponse();
            b.id = a.IdFilmeAtor;
            b.personagem = a.NmPersonagem;
            b.filme = a.IdFilme;
            b.ator = a.IdAtor;
            return b;
        }
        public List<Models.Response.personagemResponse> conversorDeResponseLista(List<Models.TbFilmeAtor> a)
        {
            List<Models.Response.personagemResponse> te = 
            a.Select(x=>new Models.Response.personagemResponse()
            {
                id = x.IdFilmeAtor,
                personagem = x.NmPersonagem,
                filme = x.IdFilme,
                ator = x.IdAtor
            }).ToList();  
            return te;
        }
        public Models.TbFilmeAtor conversorDeRequest2(int filmeid,int persoId,Models.Resquest.personagemRequest a)
        {
            Models.TbFilmeAtor b = new Models.TbFilmeAtor();
            b.NmPersonagem = a.personagem;
            b.IdFilme = filmeid;
            b.IdAtor = a.ator;
            b.IdFilmeAtor  = persoId;

            return b;
        }
    }
}