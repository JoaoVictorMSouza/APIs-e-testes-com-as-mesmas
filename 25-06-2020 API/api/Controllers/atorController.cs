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
    public class atorController : ControllerBase
    {
        Business.atorBusiness businessAtor = new Business.atorBusiness();
        Utils.atorConversor conversorAtor = new Utils.atorConversor();
        [HttpPost]
        public ActionResult<Models.Response.atorResponse> inserirAtor(Models.Resquest.atorRequest Ator)
        {
            try
            {
                Models.TbAtor a = conversorAtor.conversorDeRequest(Ator);
                
                Models.TbAtor b = businessAtor.inserirAtor(a);

                Models.Response.atorResponse c = conversorAtor.conversorDeResponse(b);
            return c;
            } catch (SystemException ex)
            {
                return new BadRequestObjectResult(new Models.Response.erroResponse(ex,400));
            }
        }
        
        [HttpGet]
        public ActionResult<Models.Response.atorResponse> consultarAtor(string nome)
        {
            try
            {
                Models.TbAtor a = businessAtor.consultarAtor(nome); 

                if(a.NmAtor==null)
                {
                    return NotFound(null);
                }
                Models.Response.atorResponse b = conversorAtor.conversorDeResponse(a);
                return b;
            } catch (SystemException ex)
            {
                return new BadRequestObjectResult(new Models.Response.erroResponse(ex,400));
            }
        }
        [HttpPut("{id}")]
        public ActionResult<Models.Response.atorResponse> Alterar(int id,Models.Resquest.atorRequest d)
        {
            try
            {
                Models.TbAtor ator = conversorAtor.conversorDeRequest2(id,d);

                Models.TbAtor a = businessAtor.alterarAtor(ator);

                Models.Response.atorResponse b = conversorAtor.conversorDeResponse(a);

                return b;
            } catch (SystemException ex)
            {
                return new BadRequestObjectResult(new Models.Response.erroResponse(ex,400));   
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Models.Response.atorResponse> consultarAtorPorId(int id)
        {
            try
            {
                Models.TbAtor a = businessAtor.consultarAtorID(id); 

                Models.Response.atorResponse b = conversorAtor.conversorDeResponse(a);
                return b;
            } catch (SystemException ex)
            {
                return new BadRequestObjectResult(new Models.Response.erroResponse(ex,400));
            }
        }
        [HttpDelete("{id}")]
        public ActionResult<Models.Response.atorResponse> deletar(int id)
        {
            try
            {
                Models.TbAtor a = businessAtor.deletarAtor(id);

                Models.Response.atorResponse b = conversorAtor.conversorDeResponse(a);

                return b;
            } catch (SystemException ex)
            {
                return new BadRequestObjectResult(new Models.Response.erroResponse(ex,400));   
            }
        }
    }
}