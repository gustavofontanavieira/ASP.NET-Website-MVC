using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyMVCSite.Models;

namespace MyMVCSite.Repositorio
{
    public interface IContatoRepositorio
    {
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);

        ContatoModel BuscarContatoId(int id);

        ContatoModel Atualizar(ContatoModel contato);

        Boolean ExcluirContatoId(int id);
    }
}
