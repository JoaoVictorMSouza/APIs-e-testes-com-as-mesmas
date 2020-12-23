using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class filmeController : ControllerBase
    {
        Business.filmeBusiness filmeBusiness = new Business.filmeBusiness();

        [HttpPost]
        public ActionResult<Models.Response.filmeResponse> Inserir(Models.Resquest.filmeResquest1 f)
        {
            try
            {
                Utils.filmeConversor conversorFilmes = new Utils.filmeConversor();

                Models.TbFilme tbdefilme = conversorFilmes.conversorDeRequest(f);

                Models.TbFilme a = filmeBusiness.Inserir(tbdefilme);

                Models.Response.filmeResponse resposta = conversorFilmes.conversorDeResponse(a);
                return resposta;
            } catch (SystemException ex)
            {
                return new BadRequestObjectResult(new Models.Response.erroResponse(ex,400));
            }
        }
        [HttpGet]
        public ActionResult<List<Models.Response.filmeResponse>> Consultar()
        {
            try
            {
                Utils.filmeConversor conversorFilmes = new Utils.filmeConversor();

                List<Models.TbFilme> a = filmeBusiness.Consultar();

                List<Models.Response.filmeResponse> resposta = conversorFilmes.conversorDeResponse2(a);
                return resposta;
            } catch (SystemException)
            {
                return new NotFoundObjectResult(new List<Models.Response.filmeResponse>());
            }
        }
        [HttpPut("{id}")]
        public ActionResult Alterar(int id,Models.Resquest.filmeResquest1 f)
        {
            try
            {
                Utils.filmeConversor conversorFilmes = new Utils.filmeConversor();

                Models.TbFilme tbdefilme = conversorFilmes.conversorDeRequest2(id,f);

                Models.TbFilme a = filmeBusiness.Alterar(tbdefilme);
                return NoContent();
            } catch (SystemException ex)
            {
                return new BadRequestObjectResult(new Models.Response.erroResponse(ex,400));    
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Models.Response.filmeResponse> ConsultarPorId(int id)
        {
            try
            {
                Utils.filmeConversor conversorFilmes = new Utils.filmeConversor();

                Models.TbFilme a = filmeBusiness.ConsultarPorId(id); 
                if(a==null)
                {
                    return NotFound(null);
                }
                Models.Response.filmeResponse b = conversorFilmes.conversorDeResponse(a);
                return b;
            } catch (SystemException)
            {
                return NotFound(null);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult deletarPorId(int id)
        {
            try
            {
                Utils.filmeConversor conversorFilmes = new Utils.filmeConversor();

                Models.TbFilme a = filmeBusiness.deletarPorId(id); 
                
                return NoContent();
            } catch (SystemException)
            {
                return NotFound(null);
            }
        }
        [HttpGet("filtrar")]
        public ActionResult<List<Models.Response.filmeResponse>> filtro(string nome, string genero)
        {
            try
            {
                Utils.filmeConversor conversorFilmes = new Utils.filmeConversor();

                List<Models.TbFilme> a = filmeBusiness.filtro(nome,genero);

                List<Models.Response.filmeResponse> resposta = conversorFilmes.conversorDeResponse2(a);
                return resposta;
            } catch (SystemException)
            {
                return new NotFoundObjectResult(new List<Models.Response.filmeResponse>());
            }
        }
        /*





        */
        Business.personagemBusiness businessPersonagem = new Business.personagemBusiness();
        Utils.personagemConversor conversorPersonagem = new Utils.personagemConversor();
        [HttpPost("{filmeid}/personagem")]
        public ActionResult<Models.Response.personagemResponse> inserirAtor(int filmeid,Models.Resquest.personagemRequest personagem)
        {
            try
            {
                Models.TbFilmeAtor a = conversorPersonagem.conversorDeRequest(filmeid,personagem);
                
                Models.TbFilmeAtor b = businessPersonagem.inserirPersonagem(a);

                Models.Response.personagemResponse c = conversorPersonagem.conversorDeResponse(b);
            return c;
            } catch (SystemException ex)
            {
                return new BadRequestObjectResult(new Models.Response.erroResponse(ex,400));
            }
        }
        [HttpGet("{filmeid}/personagem")]
        public ActionResult<List<Models.Response.personagemResponse>> conusltarPersonagemPorFilme(int filmeid)
        {
            try
            {
                List<Models.TbFilmeAtor> b = businessPersonagem.consultarPersonagemPorFilme(filmeid);
                
                List<Models.Response.personagemResponse> c = conversorPersonagem.conversorDeResponseLista(b);
                return c;
            } catch (SystemException ex)
            {
                return new BadRequestObjectResult(new Models.Response.erroResponse(ex,400));
            }
        }
        [HttpPut("{filmeid}/personagem/{persoid}")]
        public ActionResult<Models.Response.personagemResponse> Alterar(int filmeid,int persoid,Models.Resquest.personagemRequest d)
        {
            try
            {
                Models.TbFilmeAtor perso = conversorPersonagem.conversorDeRequest2(filmeid,persoid,d);

                Models.TbFilmeAtor a = businessPersonagem.AlterarPersonagemPorFilmeEAtor(perso);

                Models.Response.personagemResponse b = conversorPersonagem.conversorDeResponse(a);

                return b;
            } catch (SystemException ex)
            {
                return new BadRequestObjectResult(new Models.Response.erroResponse(ex,400));   
            }
        }
        [HttpGet("{filmeid}/personagem/{persoid}")]
        public ActionResult<Models.Response.personagemResponse> consultarAtorPorId(int filmeid,int persoid)
        {
            try
            {
                Models.TbFilmeAtor a = businessPersonagem.consultarPersonagemPorIDfilmeEperso(filmeid,persoid); 
                Models.Response.personagemResponse b = conversorPersonagem.conversorDeResponse(a);
                return b;
            } catch (SystemException ex)
            {
                return new BadRequestObjectResult(new Models.Response.erroResponse(ex,400));
            }
        }
        [HttpDelete("{filmeid}/personagem/{persoid}")]
        public ActionResult<Models.Response.personagemResponse> deletar(int filmeid,int persoid)
        {
            try
            {
                Models.TbFilmeAtor a = businessPersonagem.deletarPerso(filmeid,persoid);

                Models.Response.personagemResponse b = conversorPersonagem.conversorDeResponse(a);

                return b;
            } catch (SystemException ex)
            {
                return new BadRequestObjectResult(new Models.Response.erroResponse(ex,400));   
            }
        }
    }
}