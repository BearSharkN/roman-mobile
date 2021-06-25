using Roman_Projects.webAPI.Context;
using Roman_Projects.webAPI.Domains;
using Roman_Projects.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman_Projects.webAPI.Repositories
{
    public class EquipeRepository : IEquipeRepository
    {

        RomanContext ctx = new RomanContext();

        
        public void AtualizarEquipeUrl(int id, Equipe equipeAtualizada)
        {
            Equipe equipeBuscada = ctx.Equipes.Find(id);

            if (equipeAtualizada.TituloEquipe != null)
            {
                equipeBuscada.TituloEquipe = equipeAtualizada.TituloEquipe;
            }

            ctx.Equipes.Update(equipeBuscada);

            ctx.SaveChanges();
        }

        
        public Equipe BuscarEquipePorId(int id)
        {
            return ctx.Equipes.FirstOrDefault(e => e.IdEquipe == id);
        }

        
        public void CadastrarEquipe(Equipe novaEquipe)
        {
            ctx.Equipes.Add(novaEquipe);

            ctx.SaveChanges();
        }

        
        public void DeletarEquipe(int id)
        {
            ctx.Equipes.Remove(BuscarEquipePorId(id));

            ctx.SaveChanges();
        }

        public List<Equipe> ListarEquipes()
        {
            return ctx.Equipes.ToList();
        }
    
    
    }
}
