using AdeInvest.Servicos;
using Microsoft.AspNetCore.Mvc;
using Plataforma_Investimento_AdeInvest.Models;

namespace AdeInvest.Controladores;

[ApiController]
    [Route("api/[controller]")]
    public class MovimentacaoControlador : ControllerBase
    {
        private readonly IMovimentacaoServico _service;

        public MovimentacaoControlador(IMovimentacaoServico service)
        {
            _service = service;
        }

        [HttpPost("cadastrar")]
        public IActionResult CadastrarMovimentacao([FromBody] Movimentacao movimentacao)
        {
            _service.AdicionarMovimentacao(movimentacao);
            return Created($"api/movimentacao/{movimentacao.Id}", "Movimentação Criada com Sucesso");
        }

        [HttpPut("atualizar/{id}")]
        public IActionResult AtualizarMovimentacao(int id, [FromBody] Movimentacao movimentacao)
        {
            var movimentacaoExistente = _service.ObterMovimentacaoPorId(id);
            if (movimentacaoExistente == null)
            {
                return NotFound("Movimentação não encontrada");
            }

            _service.AtualizarMovimentacao(movimentacao);
            return Ok("Movimentação atualizada com sucesso");
        }

        [HttpDelete("deletar/{id}")]
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

        [HttpGet("todas")]
        public IActionResult ObterTodasMovimentacoes()
        {
            var movimentacoes = _service.ObterTodasMovimentacoes();
            return Ok(movimentacoes);
        }

        [HttpGet("{id}")]
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