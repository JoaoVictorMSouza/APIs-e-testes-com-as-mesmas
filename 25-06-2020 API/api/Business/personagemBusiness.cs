using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace api.Business
{
    public class personagemBusiness
    {
        Database.filmeAtorDatabase filmeAtorDatabase = new Database.filmeAtorDatabase();
        Database.filmeDatabase filmeDatabase = new Database.filmeDatabase();
        Database.atorDatabase  atorDatabase = new Database.atorDatabase();
        public Models.TbFilmeAtor inserirPersonagem(Models.TbFilmeAtor personagem)
        {
            if(string.IsNullOrEmpty(personagem.NmPersonagem)) throw new ArgumentException("Nome não pode ser vazio");
            if(personagem.IdAtor <= 0) throw new ArgumentException("Id não pode ser menor ou igual a zero");
            if(personagem.IdFilme <= 0) throw new ArgumentException("Id não pode ser menor ou igual a zero");
            if(atorDatabase.consultarAtorID(personagem.IdAtor)==null) throw new ArgumentException("Ator não encontrado");
            if(filmeDatabase.ConsultarPorId(personagem.IdFilme)==null) throw new ArgumentException("Filme não encontrado");

            Models.TbFilmeAtor d = filmeAtorDatabase.inserirPersonagem(personagem);

            return d;
        }
        public List<Models.TbFilmeAtor> consultarPersonagemPorFilme(int idFilme)
        {
            if(filmeDatabase.ConsultarPorId(idFilme)==null) throw new ArgumentException("Filme não encontrado");
            List<Models.TbFilmeAtor> a = filmeAtorDatabase.consultarPersonagemPorFilme(idFilme);
            if(a.Count==0) throw new ArgumentException("Sem personagens");
            return a;
        }
        public Models.TbFilmeAtor AlterarPersonagemPorFilmeEAtor(Models.TbFilmeAtor perso)
        {
            if(string.IsNullOrEmpty(perso.NmPersonagem)) throw new ArgumentException("Nome não pode ser vazio");
            if(perso.IdAtor <= 0) throw new ArgumentException("Id não pode ser menor ou igual a zero");
            if(filmeDatabase.ConsultarPorId(perso.IdFilme)==null) throw new ArgumentException("Filme não encontrado");
            if(atorDatabase.consultarAtorID(perso.IdAtor)==null) throw new ArgumentException("Ator não encontrado");
            if(filmeAtorDatabase.consultarPersonagemPorid(perso.IdFilmeAtor)==null) throw new ArgumentException("Personagem não encontrado");
            Models.TbFilmeAtor a = filmeAtorDatabase.AlterarPersonagemPorFilmeEAtor(perso);
            return a;
        }
        public Models.TbFilmeAtor consultarPersonagemPorIDfilmeEperso(int idfilme, int idperso)
        {
            if(idfilme <= 0) throw new ArgumentException("Id do filme não pode ser menor ou igual a zero");
            if(idperso <= 0) throw new ArgumentException("Id do personagem não pode ser menor ou igual a zero");
            if(filmeDatabase.ConsultarPorId(idfilme)==null) throw new ArgumentException("Filme não encontrado");
            if(filmeAtorDatabase.consultarPersonagemPorid(idperso)==null) throw new ArgumentException("Personagem não encontrado");
            Models.TbFilmeAtor a = filmeAtorDatabase.consultarPersonagemPorIDfilmeEperso(idfilme,idperso);
            return a;
        }
        public Models.TbFilmeAtor deletarPerso(int idfilme, int idperso)
        {
            if(idfilme <= 0) throw new ArgumentException("Id do filme não pode ser menor ou igual a zero");
            if(idperso <= 0) throw new ArgumentException("Id do personagem não pode ser menor ou igual a zero");
            if(filmeDatabase.ConsultarPorId(idfilme)==null) throw new ArgumentException("Filme não encontrado");
            if(filmeAtorDatabase.consultarPersonagemPorid(idperso)==null) throw new ArgumentException("Personagem não encontrado");
            Models.TbFilmeAtor a = filmeAtorDatabase.deletarPersonagemPorIDfilmeEperso(idfilme,idperso);
            return a;
        }
    }
}