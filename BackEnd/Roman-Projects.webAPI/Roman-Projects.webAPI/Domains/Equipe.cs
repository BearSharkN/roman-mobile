using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Roman_Projects.webAPI.Domains
{
    public partial class Equipe
    {
        public Equipe()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdEquipe { get; set; }

        [Required(ErrorMessage = "Informe o título da equipe de colaboradores")]
        public string TituloEquipe { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
