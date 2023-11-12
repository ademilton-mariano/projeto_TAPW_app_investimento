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

            var contaViewModel = _contaServico.ObterContaPorUsuarioId(usuarioCliente.Id);

            if (contaViewModel == null)
            {
                return NotFound("Conta não encontrada");
            }

            var diferenca = loginRequest.DataLogin - contaViewModel.CriadoDataHora;


            if (diferenca == null)
            {
                return NotFound("Data de login não encontrada");
            }
            
            var diferencaDias = (int)diferenca.Value.TotalDays;
            var contaExistente = _contaServico.ObterContaPorId(contaViewModel.Id);
           var rendimento = _contaServico.CalcularRendimentoEAtualizarConta(contaExistente, diferencaDias);

            var xResposta = new
            {
                Token = xToken,
                UsuarioId = usuarioCliente.Id,
                Rendimento = rendimento
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