using Roman_Projects.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman_Projects.webAPI.Interfaces
{
    interface IUsuarioRepository
    {
        void CadastrarUsuario(Usuario novoUsuario);

        List<Usuario> ListarUsuarios();

        Usuario BuscarUsuarioPorId(int id);

        void AtualizarUsuarioUrl(int id, Usuario usuarioAtualizado);

        void DeletarUsuario(int id);

        Usuario Login(string email, string senha);
    
    }
}
