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
    public class ProjetoRepository : IProjetoRepository
    {

        RomanContext ctx = new RomanContext();

        public void AtualizarProjetoUrl(int id, Projeto projetoAtualizado)
        {
            Projeto projetoBuscado = ctx.Projetos.Find(id);

            if (projetoAtualizado.IdTema != null)
            {
                projetoBuscado.IdTema = projetoAtualizado.IdTema;
            }

            if (projetoAtualizado.IdUsuario > 0)  //outra forma de verificar se o id foi informado
            {
                projetoBuscado.IdUsuario = projetoAtualizado.IdUsuario;
            }

            if (projetoAtualizado.DescricaoProjeto != null)
            {
                projetoBuscado.DescricaoProjeto = projetoAtualizado.DescricaoProjeto;
            }

            ctx.Projetos.Update(projetoBuscado);

            ctx.SaveChanges();
        }

        public Projeto BuscarProjetoPorId(int id)
        {
            return ctx.Projetos.FirstOrDefault(p => p.IdProjeto == id);
        }

        public void CadastrarProjeto(Projeto novoProjeto)
        {
            ctx.Projetos.Add(novoProjeto);

            ctx.SaveChanges(); //quando há alguma forma de alteração dos dados precisamos salvar, com EF Core
        }

        public void DeletarProjeto(int id)
        {
            ctx.Projetos.Remove(BuscarProjetoPorId(id));

            ctx.SaveChanges();
        }

        public List<Projeto> ListarProjetos()
        {
            return ctx.Projetos
                
                //adiciona na lista as informações dos campos das entidades relacionadas com projeto (tema e usuário)
                .Include(p => p.IdTemaNavigation)
                .Include(p => p.IdUsuarioNavigation)
                
                .ToList();
        }
    
    }
}
