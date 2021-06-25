using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Roman_Projects.webAPI.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Projetos = new HashSet<Projeto>();
        }

        public int IdUsuario { get; set; }
        public int IdTipoUsuario { get; set; }
        public int IdEquipe { get; set; }
        
        
        [Required(ErrorMessage = "Informe o nome de usuário")]
        public string NomeUsuario { get; set; }
        
        
        [Required(ErrorMessage = "Informe o email do usuário")]
        public string Email { get; set; }
        
        
        [Required(ErrorMessage = "Informe a senha do usuário")]
        public string Senha { get; set; }

        public virtual Equipe IdEquipeNavigation { get; set; }
        public virtual TiposUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Projeto> Projetos { get; set; }
    }
}
