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
    }
}
