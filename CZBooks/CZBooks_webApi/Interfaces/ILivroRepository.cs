using CZBooks_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CZBooks_webApi.Interfaces
{
    interface ILivroRepository
    {
        List<Livro> Listar();

        Livro BuscarPorId(int id);

        void Cadastrar(Livro novoLivro);

        void Atualizar(int id, Livro novoLivro);

        void Deletar(int id);
    }
}
