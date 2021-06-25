using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Roman_Projects.webAPI.Domains
{
    public partial class Projeto
    {
        public int IdProjeto { get; set; }    //ORM acaba capitalizando o nome dos campos da tabela do banco de dados
        
        
        [Required(ErrorMessage = "Informe o id do tema do projeto")]
        public int? IdTema { get; set; }  //ORM acaba vindo com ? na definição de propriedades 'int'

        
        [Required(ErrorMessage = "Informe o id do usuário que cadastrou o projeto")]
        public int? IdUsuario { get; set; }

        
        [Required(ErrorMessage = "Informe a descrição do projeto")]
        public string DescricaoProjeto { get; set; }

        
        public virtual Tema IdTemaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    
    }
}
