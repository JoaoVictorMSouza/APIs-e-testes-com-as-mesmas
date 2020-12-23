using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace api.Utils
{
    public class atorConversor
    {
        public Models.TbAtor conversorDeRequest(Models.Resquest.atorRequest a)
        {
            Models.TbAtor b = new Models.TbAtor();
            b.NmAtor = a.nome;
            b.VlAltura = a.altura;
            b.DtNascimento = a.nascimento;

            return b;
        }
        public Models.Response.atorResponse conversorDeResponse(Models.TbAtor a)
        {
            Models.Response.atorResponse b = new Models.Response.atorResponse();
            b.id = a.IdAtor;
            b.nome = a.NmAtor;
            b.altura = a.VlAltura;
            b.nascimento = a.DtNascimento;

            return b;
        }
        public Models.TbAtor conversorDeRequest2(int id,Models.Resquest.atorRequest a)
        {
            Models.TbAtor b = new Models.TbAtor();
            b.IdAtor = id;
            b.NmAtor = a.nome;
            b.VlAltura = a.altura;
            b.DtNascimento = a.nascimento;

            return b;
        }
    }
}