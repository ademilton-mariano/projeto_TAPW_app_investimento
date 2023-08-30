using AdeInvest.Servicos;
using Microsoft.AspNetCore.Mvc;
using SecureIdentity.Password;

namespace AdeInvest.Contoladores;

    [ApiController]
    [Route("api/[controller]")]
    public class LoginControlador : ControllerBase
    {
        private readonly IUsuarioClienteServico _usuarioClienteService;

        public LoginControlador(IUsuarioClienteServico usuarioClienteService)
        {
            _usuarioClienteService = usuarioClienteService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            var usuarioCliente = _usuarioClienteService.ObterUsuarioClientePorEmail(loginRequest.Email);

            if (usuarioCliente == null || !PasswordHasher.Verify(loginRequest.Senha, usuarioCliente.Senha))
            {
                return Unauthorized("Email ou senha incorretos");
            }

            return Ok("Login bem-sucedido");
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {

            return Ok("Logout bem-sucedido");
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }