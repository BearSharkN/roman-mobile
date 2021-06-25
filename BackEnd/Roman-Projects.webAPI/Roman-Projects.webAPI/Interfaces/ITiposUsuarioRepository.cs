using Roman_Projects.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman_Projects.webAPI.Interfaces
{
    interface ITiposUsuarioRepository
    {
        void CadastrarTipoUsuario(TiposUsuario novoTipoUsuario);

        List<TiposUsuario> ListarTiposUsuarios();

        TiposUsuario BuscarTipoUsuarioPorId(int id);

        void AtualizarTipoUsuarioUrl(int id, TiposUsuario tipoUsuarioAtualizado);

        void DeletarTipoUsuario(int id);
    }
}
