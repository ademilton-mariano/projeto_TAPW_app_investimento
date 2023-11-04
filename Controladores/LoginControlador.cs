using AdeInvest.Servicos;
using Microsoft.AspNetCore.Mvc;
using SecureIdentity.Password;

namespace AdeInvest.Controladores;

    [ApiController]
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

            if (usuarioCliente == null || !PasswordHasher.Verify(usuarioCliente.Senha, loginRequest.Senha))
            {
                return Unauthorized("Email ou senha incorretos");
            }

            _usuarioClienteServico.AtualizarDataUltimoLogin(usuarioCliente, loginRequest.DataLogin ?? DateTime.UtcNow);
            var xToken = _jwtService.GenerateToken(usuarioCliente);

            var xResposta = new
            {
                Token = xToken,
                UsuarioId = usuarioCliente.Id
            };

            return Ok(xResposta);
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {

            return Ok("Logout bem-sucedido");
        }
    }

    public class LoginRequest
    {
        public DateTime? DataLogin { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }