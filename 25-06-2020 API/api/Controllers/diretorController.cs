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
    public class diretorController : ControllerBase
    {
        Business.diretorBusiness businessDiretor = new Business.diretorBusiness();

        [HttpPost]
        public ActionResult<Models.Response.diretorResponse> inserirDiretor(Models.Resquest.diretorRequest diretor)
        {
            try
            {

                Utils.diretorConversor conversorDiretor = new Utils.diretorConversor();
                Models.TbDiretor a = conversorDiretor.conversorDeRequest(diretor);
                Models.TbDiretor b = businessDiretor.inserirDiretor(a);

                Models.Response.diretorResponse c = conversorDiretor.conversorDeResponse(b);
            return c;
            } catch (SystemException ex)
            {
                return new BadRequestObjectResult(new Models.Response.erroResponse(ex,400));
            }
        }
        [HttpGet]
        public ActionResult<Models.Response.diretorResponse> consultarDiretor(string nome)
        {
            try
            {
                Utils.diretorConversor conversorDiretor = new Utils.diretorConversor();

                Models.TbDiretor a = businessDiretor.consultarDiretor(nome); 

                if(a.NmDiretor==null)
                {
                    return NotFound(null);
                }
                Models.Response.diretorResponse b = conversorDiretor.conversorDeResponse(a);
                return b;
            } catch (SystemException ex)
            {
                return new BadRequestObjectResult(new Models.Response.erroResponse(ex,400));
            }
        }
        [HttpPut("{id}")]
        public ActionResult<Models.Response.diretorResponse> Alterar(int id,Models.Resquest.diretorRequest d)
        {
            try
            {
                Utils.diretorConversor conversorDiretor = new Utils.diretorConversor();

                Models.TbDiretor tbdedeiretor = conversorDiretor.conversorDeRequest2(id,d);

                Models.TbDiretor a = businessDiretor.alterarDiretor(tbdedeiretor);

                Models.Response.diretorResponse b = conversorDiretor.conversorDeResponse(a);

                return b;
            } catch (SystemException ex)
            {
                return new BadRequestObjectResult(new Models.Response.erroResponse(ex,400));   
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Models.Response.diretorResponse> consultarDiretorPorId(int id)
        {
            try
            {
                Utils.diretorConversor conversorDiretor = new Utils.diretorConversor();

                Models.TbDiretor a = businessDiretor.consultarDiretorID1(id); 
                Models.Response.diretorResponse b = conversorDiretor.conversorDeResponse(a);
                return b;
            } catch (SystemException ex)
            {
                return new BadRequestObjectResult(new Models.Response.erroResponse(ex,400));
            }
        }
        [HttpDelete("{id}")]
        public ActionResult<Models.Response.diretorResponse> deletar(int id)
        {
            try
            {
                Utils.diretorConversor conversorDiretor = new Utils.diretorConversor();

                Models.TbDiretor a = businessDiretor.deletarDiretor(id);

                Models.Response.diretorResponse b = conversorDiretor.conversorDeResponse(a);

                return b;
            } catch (SystemException ex)
            {
                return new BadRequestObjectResult(new Models.Response.erroResponse(ex,400));   
            }
        }
    }
}