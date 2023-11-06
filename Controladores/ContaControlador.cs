using AdeInvest.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plataforma_Investimento_AdeInvest.Models;

namespace AdeInvest.Controladores;

[Authorize]
[ApiController]
[Route("conta")]
public class ContaControlador : ControllerBase
{
    private readonly IContaServico _servico;

    public ContaControlador(IContaServico servico)
    {
        _servico = servico;
    }

    [HttpPost("")]
    public IActionResult CadastrarConta([FromBody] Conta conta)
    {
        _servico.AdicionarConta(conta);
        return Created($"conta/{conta.Id}", "Conta Criada com Sucesso");
    }

    [HttpPut("{id:int}")]
    public IActionResult AtualizarConta(int id, [FromBody] Conta conta)
    {
        var contaExistente = _servico.ObterContaPorUsuarioId(id);
        if (contaExistente == null)
        {
            return NotFound("Conta não encontrada");
        }

        _servico.AtualizarConta(conta);
        return Ok("Conta atualizada com sucesso");
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarConta(int id)
    {
        var contaExistente = _servico.ObterContaPorUsuarioId(id);
        if (contaExistente == null)
        {
            return NotFound("Conta não encontrada");
        }

        _servico.DeletarConta(id);
        return Ok("Conta deletada com sucesso");
    }

    [HttpGet("")]
    public IActionResult ObterTodasContas()
    {
        var contas = _servico.ObterTodasContas();
        return Ok(contas);
    }

    [HttpGet("{id:int}")]
    public IActionResult ObterContaPorUsuarioId(int id)
    {
        var conta = _servico.ObterContaPorUsuarioId(id);
        if (conta == null)
        {
            return NotFound("Conta não encontrada");
        }

        return Ok(conta);
    }
}
