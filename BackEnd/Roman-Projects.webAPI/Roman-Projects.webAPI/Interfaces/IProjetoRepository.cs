using Roman_Projects.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman_Projects.webAPI.Interfaces
{
    interface IProjetoRepository
    {
        void CadastrarProjeto(Projeto novoProjeto);

        List<Projeto> ListarProjetos();

        Projeto BuscarProjetoPorId(int id);

        void AtualizarProjetoUrl(int id, Projeto projetoAtualizado);

        void DeletarProjeto(int id);
    }
}
