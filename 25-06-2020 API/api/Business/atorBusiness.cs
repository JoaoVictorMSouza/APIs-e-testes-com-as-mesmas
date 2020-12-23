using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace api.Business
{
    public class atorBusiness
    {
        Database.atorDatabase atorDatabase = new Database.atorDatabase();
        public Models.TbAtor inserirAtor(Models.TbAtor ator)
        {
            if(string.IsNullOrEmpty(ator.NmAtor)) throw new ArgumentException("Nome não pode ser vazio");
            if(ator.VlAltura <= 0.15m) throw new ArgumentException("Altura não pode ser menor que 15cm");

            Models.TbAtor d = atorDatabase.inserirAtor(ator);

            return d;
        }
        public Models.TbAtor consultarAtor(string nome)
        {
            if(string.IsNullOrEmpty(nome)) throw new ArgumentException("Campo inválido");
            Models.TbAtor d = atorDatabase.consultarAtor(nome);
            if(d == null) throw new ArgumentException("Não encontrado");
            return d;
        }
        public Models.TbAtor alterarAtor(Models.TbAtor ator)
        {
            if(string.IsNullOrEmpty(ator.NmAtor)) throw new ArgumentException("Nome não pode ser vazio");
            if(ator.IdAtor <= 0) throw new ArgumentException("Id não  pode ser menor ou igual a zero");
            if(ator.VlAltura <= 0.15m) throw new ArgumentException("Altura não pode ser menor que 15cm");

            Models.TbAtor a = atorDatabase.alterarAtor(ator);
            return a;
        }
        public Models.TbAtor consultarAtorID(int id)
        {
            if(id <= 0) throw new ArgumentException("Id não  pode ser menor ou igual a zero");
            Models.TbAtor d = atorDatabase.consultarAtorID(id);
            if(d == null) throw new ArgumentException("Ator não encontrado");
            return d;
        }
        public Models.TbAtor deletarAtor(int id)
        {
            if(id <= 0) throw new ArgumentException("Id não  pode ser menor ou igual a zero");
            
            Models.TbAtor a = atorDatabase.deletarAtor(id);
            return a;
        }
    }
}