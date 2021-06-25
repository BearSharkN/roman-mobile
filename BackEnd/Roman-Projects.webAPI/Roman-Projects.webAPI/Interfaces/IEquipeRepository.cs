using Roman_Projects.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman_Projects.webAPI.Interfaces
{
    interface IEquipeRepository
    {
        void CadastrarEquipe(Equipe novaEquipe);

        List<Equipe> ListarEquipes();

        Equipe BuscarEquipePorId(int id);

        void AtualizarEquipeUrl(int id, Equipe equipeAtualizada);

        void DeletarEquipe(int id);
    }
}
