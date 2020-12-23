using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace api.Business
{
    public class diretorBusiness
    {
        Database.diretorDatabase diretorDatabase = new Database.diretorDatabase();
        public Models.TbDiretor inserirDiretor(Models.TbDiretor diretor)
        {
            if(string.IsNullOrEmpty(diretor.NmDiretor)) throw new ArgumentException("Nome não pode ser vazio");
            if(diretor.IdFilme <= 0) throw new ArgumentException("Id não  pode ser menor ou igual a zero");

            Models.TbDiretor d = diretorDatabase.inserirDiretor(diretor);

            return d;
        }
        public Models.TbDiretor consultarDiretor(string nome)
        {
            if(string.IsNullOrEmpty(nome)) throw new ArgumentException("Campo inválido");
            Models.TbDiretor d = diretorDatabase.consultarDiretor(nome);
            if(d == null) throw new ArgumentException("Campo inválido");
            return d;
        }
        public Models.TbDiretor alterarDiretor(Models.TbDiretor diretor)
        {
            if(string.IsNullOrEmpty(diretor.NmDiretor)) throw new ArgumentException("Nome não pode ser vazio");
            if(diretor.IdFilme <= 0) throw new ArgumentException("Id não  pode ser menor ou igual a zero");
            if(diretor.IdDiretor <=0 ) throw new ArgumentException("Id do diretor inválido");

            Models.TbDiretor a = diretorDatabase.alterarDiretor(diretor);
            return a;
        }
        public Models.TbDiretor consultarDiretorID1(int id)
        {
            Models.TbDiretor d = diretorDatabase.consultarDiretorID(id);
            return d;
        }
        public Models.TbDiretor deletarDiretor(int id)
        {
            if(id <= 0) throw new ArgumentException("Id não  pode ser menor ou igual a zero");
            if(consultarDiretorID1(id) == null)
            {
                throw new ArgumentException("Id não encontrado");
            };
            Models.TbDiretor a = diretorDatabase.deletarDiretor(id);
            if(a == null) throw new ArgumentException("Id não encontrado");
            return a;
        }
    }
}