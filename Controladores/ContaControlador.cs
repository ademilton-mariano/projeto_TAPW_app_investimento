using AdeInvest.Servicos;
using Microsoft.AspNetCore.Mvc;
using Plataforma_Investimento_AdeInvest.Models;

namespace AdeInvest.Controladores;

public class ContaControlador : ControllerBase
{
    private readonly IContaServico _servico;

    public ContaControlador(IContaServico servico)
    {
        _servico = servico;
    }

    [HttpPost("conta-cadastrar")]
    public IActionResult CadastrarConta([FromBody] Conta conta)
    {
        _servico.AdicionarConta(conta);
        return Created($"api/conta/{conta.Id}", "Conta Criada com Sucesso");
    }

    [HttpPut("conta-atualizar/{id}")]
    public IActionResult AtualizarConta(int id, [FromBody] Conta conta)
    {
        var contaExistente = _servico.ObterContaPorId(id);
        if (contaExistente == null)
        {
            return NotFound("Conta não encontrada");
        }

        _servico.AtualizarConta(conta);
        return Ok("Conta atualizada com sucesso");
    }

    [HttpDelete("conta-deletar/{id}")]
    public IActionResult DeletarConta(int id)
    {
        var contaExistente = _servico.ObterContaPorId(id);
        if (contaExistente == null)
        {
            return NotFound("Conta não encontrada");
        }

        _servico.DeletarConta(id);
        return Ok("Conta deletada com sucesso");
    }

    [HttpGet("conta-todas")]
    public IActionResult ObterTodasContas()
    {
        var contas = _servico.ObterTodasContas();
        return Ok(contas);
    }

    [HttpGet("conta/{id}")]
    public IActionResult ObterContaPorId(int id)
    {
        var conta = _servico.ObterContaPorId(id);
        if (conta == null)
        {
            return NotFound("Conta não encontrada");
        }

        return Ok(conta);
    }
}
