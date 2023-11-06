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
        private readonly IContaServico _contaServico;

        public LoginControlador(IUsuarioClienteServico usuarioClienteServico, JwtServico jwtService, IConfiguration configuration, IContaServico contaServico)
        {
            _usuarioClienteServico = usuarioClienteServico;
            _jwtService = jwtService;
            _configuration = configuration;
            _contaServico = contaServico;
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

            var dataCriacao = _contaServico.ObterContaPorUsuarioId(usuarioCliente.Id).CriadoDataHora;

            if (dataCriacao == null)
            {
                return NotFound("Conta não encontrada");
            }

            var diferenca = loginRequest.DataLogin - dataCriacao;


            var diferencaDias = (int)diferenca.Value.TotalDays;

            var xResposta = new
            {
                Token = xToken,
                UsuarioId = usuarioCliente.Id,
                DiasInvestimento = diferencaDias
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