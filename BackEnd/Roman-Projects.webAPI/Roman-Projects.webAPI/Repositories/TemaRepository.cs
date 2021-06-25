using Roman_Projects.webAPI.Context;
using Roman_Projects.webAPI.Domains;
using Roman_Projects.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman_Projects.webAPI.Repositories
{
    public class TemaRepository : ITemaRepository
    {

        RomanContext ctx = new RomanContext();

        public void AtualizarTemaUrl(int id, Tema temaAtualizado)
        {
            Tema temaBuscado = ctx.Temas.Find(id);

            if (temaAtualizado.DescricaoTema != null)
            {
                temaBuscado.DescricaoTema = temaAtualizado.DescricaoTema;
            }

            temaBuscado.SituacaoTema = temaAtualizado.SituacaoTema;

            ctx.Temas.Update(temaBuscado);

            ctx.SaveChanges();
        }

        public Tema BuscarTemaPorId(int id)
        {
            return ctx.Temas.FirstOrDefault(t => t.IdTema == id);
        }

        public void CadastrarTema(Tema novoTema)
        {
            ctx.Temas.Add(novoTema);

            ctx.SaveChanges();
        }

        public void DeletarTema(int id)
        {
            ctx.Temas.Remove(BuscarTemaPorId(id));

            ctx.SaveChanges();
        }

        public List<Tema> ListarTemas()
        {
            return ctx.Temas.ToList();
        }
    }
}
