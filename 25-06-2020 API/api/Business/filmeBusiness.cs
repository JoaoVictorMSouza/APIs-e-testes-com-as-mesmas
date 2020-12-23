using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace api.Business
{
    public class filmeBusiness
    {
        Database.filmeDatabase filmeDatabase = new Database.filmeDatabase();
        public Models.TbFilme Inserir(Models.TbFilme f)
        {
            if(string.IsNullOrEmpty(f.NmFilme)) throw new ArgumentException("O nome é obrigatorio.");
            if(string.IsNullOrEmpty(f.DsGenero)) throw new ArgumentException("O genero é obrigatorio.");
            if(f.VlAvaliacao < 0) throw new ArgumentException("Avalição não pode ser menor que 0");
            if(f.NrDuracao <= 0) throw new ArgumentException("Duração inválida.");

            Models.TbFilme filmec = filmeDatabase.Inserir(f);

            return filmec;
        }
        public List<Models.TbFilme> Consultar()
        {
            List<Models.TbFilme> filmec = filmeDatabase.Consultar();
            if(filmec.Count == 0) throw new ArgumentException();

            return filmec;
        }
        public Models.TbFilme Alterar(Models.TbFilme f)
        {
            if(f.IdFilme <= 0) throw new ArgumentException("Id invalido.");
            if(string.IsNullOrEmpty(f.NmFilme)) throw new ArgumentException("O nome é obrigatorio.");
            if(string.IsNullOrEmpty(f.DsGenero)) throw new ArgumentException("O genero é obrigatorio.");
            if(f.VlAvaliacao < 0) throw new ArgumentException("Avalição não pode ser menor que 0");
            if(f.NrDuracao <= 0) throw new ArgumentException("Duração inválida.");

            Models.TbFilme filmec = filmeDatabase.Alterar(f);

            return filmec;
        }
        public Models.TbFilme ConsultarPorId(int id)
        {
            if (id <= 0) throw new ArgumentException("Id invalido.");
            Models.TbFilme filmec = filmeDatabase.ConsultarPorId(id);

            return filmec;
        }
        public Models.TbFilme deletarPorId(int id)
        {
            if (id <= 0) throw new ArgumentException("Id invalido.");
            Models.TbFilme filmec = filmeDatabase.deletarPorId(id);

            return filmec;
        }
        public List<Models.TbFilme> filtro(string nome, string genero)
        {
            List<Models.TbFilme> filmec = filmeDatabase.filtro(nome,genero);
            if(filmec.Count == 0) throw new ArgumentException();

            return filmec;
        }         
    }
}