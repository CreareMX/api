using CommonApplication.Interfaces;
using EssentialApplication.dtos;
using EssentialApplication.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MultiSystemApi.Controllers.Seguridad
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        readonly IJwt _jwt;
        readonly IUsuarioService _usuarioService;
        public LoginController(IJwt jwt, IUsuarioService usuarioService)
        {
            _jwt = jwt;
            _usuarioService = usuarioService;
        }
        [HttpPost]
        public IActionResult Login(UsuarioDto usuario)
        {
            try
            {
                using (var encripter = SHA256.Create())
                {
                    var hashLogin = encripter.ComputeHash(Encoding.ASCII.GetBytes(usuario.Contrasena));
                    var stringHash = string.Empty;
                    for (int i = 0; i < hashLogin.Length; i++)
                    {
                        stringHash += ($"{hashLogin[i]:X2}");
                        if ((i % 4) == 3) stringHash += " ";
                    }

                    var usuarioAutenticado = _usuarioService.Login(usuario.NombreUsuario, stringHash.Trim());
                    if (usuarioAutenticado != null)
                    {
                        var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _jwt.Issuer),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", usuario.Id.ToString()),
                        new Claim("DisplayName", usuario.NombreUsuario),
                        new Claim("UserName", usuario.NombreUsuario),
                        new Claim("Email", usuario.NombreUsuario)
                    };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            _jwt.Issuer,
                            _jwt.Audience,
                            claims,
                            expires: DateTime.UtcNow.AddSeconds(_jwt.ExpirationSeconds),
                            signingCredentials: signIn);

                        return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                    }
                    return Unauthorized();
                }
            }catch(Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
