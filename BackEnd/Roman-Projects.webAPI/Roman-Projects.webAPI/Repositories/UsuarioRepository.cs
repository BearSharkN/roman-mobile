using Microsoft.EntityFrameworkCore;
using Roman_Projects.webAPI.Context;
using Roman_Projects.webAPI.Domains;
using Roman_Projects.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman_Projects.webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository  //utilizar o select na listagem e em buscar por id!
    {                                                   // pois o include manda todas as informações relacionadas (demais)

        RomanContext ctx = new RomanContext();

        public void AtualizarUsuarioUrl(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            if (usuarioAtualizado.NomeUsuario != null)
            {
                usuarioBuscado.NomeUsuario = usuarioAtualizado.NomeUsuario;
            }

            if (usuarioAtualizado.IdTipoUsuario > 0)
            {
                usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;
            }

            if (usuarioAtualizado.IdEquipe != null)
            {
                usuarioBuscado.IdEquipe = usuarioAtualizado.IdEquipe;
            }

            if (usuarioAtualizado.Email != null)
            {
                usuarioBuscado.Email = usuarioAtualizado.Email;
            }

            if (usuarioAtualizado.Senha != null)  //junto com data annotations para validação?
            {
                usuarioBuscado.Senha = usuarioAtualizado.Senha;
            }

            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();

        }

        
        public Usuario BuscarUsuarioPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
        }

        public void CadastrarUsuario(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void DeletarUsuario(int id)
        {
            ctx.Usuarios.Remove(BuscarUsuarioPorId(id));

            ctx.SaveChanges();
        }

        public List<Usuario> ListarUsuarios()
        {
            return ctx.Usuarios

                .Include(u => u.IdTipoUsuarioNavigation)
                .Include(u => u.IdEquipeNavigation)

                .ToList();
        }


        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    
    
    }
}
