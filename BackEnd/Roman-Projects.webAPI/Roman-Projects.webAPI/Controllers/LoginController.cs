using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Roman_Projects.webAPI.Domains;
using Roman_Projects.webAPI.Interfaces;
using Roman_Projects.webAPI.Repositories;
using Roman_Projects.webAPI.ViewModels;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace Roman_Projects.webAPI.Controllers
{

    [Produces("application/json")]
    
    [Route("api/[controller]")]
    
    [ApiController]
    
    public class LoginController : ControllerBase
    {

        private IUsuarioRepository _usuarioRepository { get; set; }


        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        // aqui é Post pois se fosse Get, o email e a senha ficariam 'expostos' passando pela URL da requisição
        {

            try
            {

                Usuario usuarioBuscado = _usuarioRepository.Login(login.Email,login.Senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("email ou senha inválidos");
                }

                var claims = new[] //talvez tenha que adicionar claims aqui dependendo da necessidade
                {
                    
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString()),

                    new Claim("equipe", usuarioBuscado.IdEquipe.ToString()), //claim personalizada para definir a 'equipe'

                    new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.NomeUsuario),

                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),

                    new Claim("role", usuarioBuscado.IdTipoUsuario.ToString()) //claim personalizada para definir a 'role'

                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("roman-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); //pesquisar sobre HmacSha256

                var token = new JwtSecurityToken (
                    issuer: "Roman_Projects.webAPI",
                    audience: "Roman_Projects.webAPI",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: creds
                );

                return Ok(new
                { 
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            
            
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    
    }
}
