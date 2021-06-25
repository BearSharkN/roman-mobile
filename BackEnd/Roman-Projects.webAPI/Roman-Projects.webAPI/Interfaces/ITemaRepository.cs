using Roman_Projects.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman_Projects.webAPI.Interfaces
{
    interface ITemaRepository
    {
        void CadastrarTema(Tema novoTema);

        List<Tema> ListarTemas();

        Tema BuscarTemaPorId(int id);

        void AtualizarTemaUrl(int id, Tema temaAtualizado);

        void DeletarTema(int id);

    }
}
