using chapterWebAPI.Models;
using chapterWebAPI.Repositories;
using chapterWebAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace chapterWebAPI.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;

        public LoginController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuarios usuarioBuscado = _usuarioRepository.Login(login.email, login.senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("E-mail e/ou senha inválidos");
                }

                var minhasClaims = new[] {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.Tipo.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chapter-chave-autenticacao"));

                var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var meuToken = new JwtSecurityToken(
                    issuer: "chapterWebAPI",
                    audience: "chapterWebAPI",
                    claims: minhasClaims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: cred
               );

                return Ok(
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(meuToken),
                    }
               );

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
