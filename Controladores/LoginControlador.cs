using AdeInvest.Servicos;
using Microsoft.AspNetCore.Mvc;
using SecureIdentity.Password;

namespace AdeInvest.Contoladores;

    [ApiController]
    [Route("api/[controller]")]
    public class LoginControlador : ControllerBase
    {
        private readonly IUsuarioClienteServico _usuarioClienteServico;
        private readonly JwtServico _jwtService;
        private readonly IConfiguration _configuration;

        public LoginControlador(IUsuarioClienteServico usuarioClienteServico, JwtServico jwtService, IConfiguration configuration)
        {
            _usuarioClienteServico = usuarioClienteServico;
            _jwtService = jwtService;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            var usuarioCliente = _usuarioClienteServico.ObterUsuarioClientePorEmail(loginRequest.Email);

            if (usuarioCliente == null || !PasswordHasher.Verify(loginRequest.Senha, usuarioCliente.Senha))
            {
                return Unauthorized("Email ou senha incorretos");
            }

            var token = _jwtService.GenerateToken(usuarioCliente);

            return Ok(new { Token = token });
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