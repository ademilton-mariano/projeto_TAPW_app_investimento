using AdeInvest.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plataforma_Investimento_AdeInvest.Models;

namespace AdeInvest.Controladores;

    [Authorize]
    [ApiController]
    [Route("movimentacao")]
    public class MovimentacaoControlador : ControllerBase
    {
        private readonly IMovimentacaoServico _service;

        public MovimentacaoControlador(IMovimentacaoServico service)
        {
            _service = service;
        }

        [HttpPost("")]
        public IActionResult CadastrarMovimentacao([FromBody] Movimentacao movimentacao)
        {
            _service.AdicionarMovimentacao(movimentacao);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeletarMovimentacao(int id)
        {
            var movimentacaoExistente = _service.ObterMovimentacaoPorId(id);
            if (movimentacaoExistente == null)
            {
                return NotFound("Movimentação não encontrada");
            }

            _service.DeletarMovimentacao(id);
            return Ok("Movimentação deletada com sucesso");
        }

        [HttpGet("")]
        public IActionResult ObterTodasMovimentacoes()
        {
            var movimentacoes = _service.ObterTodasMovimentacoes();
            return Ok(movimentacoes);
        }

        [HttpGet("{id:int}")]
        public IActionResult ObterMovimentacaoPorId(int id)
        {
            var movimentacao = _service.ObterMovimentacaoPorId(id);
            if (movimentacao == null)
            {
                return NotFound("Movimentação não encontrada");
            }

            return Ok(movimentacao);
        }
    }