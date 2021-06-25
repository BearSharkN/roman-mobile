using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Roman_Projects.webAPI.Domains
{
    public partial class TiposUsuario
    {
        public TiposUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }

        
        [Required(ErrorMessage = "Informe o título do tipo de usuário")]
        public string TituloTipoUsuario { get; set; }

        
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
