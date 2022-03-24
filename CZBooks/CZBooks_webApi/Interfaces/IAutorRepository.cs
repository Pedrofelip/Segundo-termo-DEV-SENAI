using CZBooks_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CZBooks_webApi.Interfaces
{
    interface IAutorRepository
    {
        
        List<Autore> Listar();

        Autore BuscarPorId(int id);

        void Cadastrar(Autore novoAutor);

        void Atualizar(int id, Autore AutorAtualizado);

        void Deletar(int id);

        List<Autore> ListarMeusLivros();
    }
}
