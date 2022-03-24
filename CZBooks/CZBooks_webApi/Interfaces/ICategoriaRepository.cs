using CZBooks_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CZBooks_webApi.Interfaces
{
    interface ICategoriaRepository
    {
        
        List<Categoria> Listar();

        Categoria BuscarPorId(int id);

       void Cadastrar(Categoria novaCategoria);

        void Atualizar(int id, Categoria novaCategoria);

        void Deletar(int id);
    }
}
