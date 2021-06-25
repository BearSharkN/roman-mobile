using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Roman_Projects.webAPI.ViewModels
{
    public class LoginViewModel   //o método de validar o usuário está em UsuarioRepository
    {

        [Required(ErrorMessage = "Informe o email do usuário")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário")]
        public string Senha { get; set; }
    
    }
}
