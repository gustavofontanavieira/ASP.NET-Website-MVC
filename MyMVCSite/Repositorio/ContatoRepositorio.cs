using MyMVCSite.Data;
using MyMVCSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMVCSite.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _context;
        public ContatoRepositorio(BancoContext bancoContext)
        {
           this._context = bancoContext;
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            //Inserção do banco
            _context.Contatos.Add(contato);
            _context.SaveChanges();

            return contato;
        }

        public List<ContatoModel> BuscarTodos() 
        {
            return _context.Contatos.ToList();
        }

        public ContatoModel BuscarContatoId(int id)
        {
            return _context.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = this.BuscarContatoId(contato.Id);
            if (contatoDB == null) throw new Exception("Houve um erro na atualização do contato");

            contatoDB.Email = contato.Email;
            contatoDB.Nome = contato.Nome;
            contatoDB.Numero = contato.Numero;

            _context.Contatos.Update(contatoDB);
            _context.SaveChanges();

            return contatoDB;
        }

        public Boolean ExcluirContatoId(int id)
        {
            ContatoModel contatoAchado = this.BuscarContatoId(id);
            if (contatoAchado == null) throw new Exception("Houve um erro ao deletar contato");
            _context.Contatos.Remove(contatoAchado);
            _context.SaveChanges();
            return true;
        }

    }
}
