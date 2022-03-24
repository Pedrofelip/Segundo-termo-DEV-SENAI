using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IPersonagemRepository
    {
        //Definição dos métodos - CRUD

        /// <summary>
        /// Cadastrar um novo personagem
        /// </summary>
        /// <param name="personagem">objeto habilidade a ser criado</param>

        void Cadastrar(Personagem personagem);

        /// <summary>
        /// Listar os personagens 
        /// </summary>
        /// <returns>lista dos personagens</returns>
        List<Personagem> Listar();

        /// <summary>
        /// Buscar um personagem pelo seu id
        /// </summary>
        /// <param name="id">id do personagem a ser buscada</param>
        /// <returns>personagem buscada</returns>
        Personagem BuscarPorId(int id);

        /// <summary>
        /// Atualizar um personagem existente 
        /// </summary>
        /// <param name="id">id do personagem a ser atualizado</param>
        /// <param name="personagem">objeto personagem com as novas informações</param>
        void Atualizar(int id, Personagem personagem);

        /// <summary>
        /// Deleta uma personagem existente
        /// </summary>
        /// <param name="id">id do personagem a ser deletada</param>
        void Deletar(int id);
    }
}
