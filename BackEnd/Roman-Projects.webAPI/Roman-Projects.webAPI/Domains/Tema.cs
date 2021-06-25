using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Roman_Projects.webAPI.Domains
{
    public partial class Tema
    {
        public Tema()
        {
            Projetos = new HashSet<Projeto>();
        }

        public int IdTema { get; set; }

        
        [Required(ErrorMessage = "Informe a descrição do tema do projeto")]
        public string DescricaoTema { get; set; }

        
        public bool? SituacaoTema { get; set; }

        
        public virtual ICollection<Projeto> Projetos { get; set; }
    }
}
