using AdeInvest.Servicos;
using Microsoft.AspNetCore.Mvc;
using Plataforma_Investimento_AdeInvest.Models;

namespace AdeInvest.Contoladores;

[ApiController]
[Route("api/[controller]")]
public class ContaControlador : ControllerBase
{
    private readonly IContaServico _servico;

    public ContaControlador(IContaServico servico)
    {
        _servico = servico;
    }

    [HttpPost("cadastrar")]
    public IActionResult CadastrarConta([FromBody] Conta conta)
    {
        _servico.AdicionarConta(conta);
        return Created($"api/conta/{conta.Id}", "Conta Criada com Sucesso");
    }

    [HttpPut("atualizar/{id}")]
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

    [HttpDelete("deletar/{id}")]
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

    [HttpGet("todas")]
    public IActionResult ObterTodasContas()
    {
        var contas = _servico.ObterTodasContas();
        return Ok(contas);
    }

    [HttpGet("{id}")]
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
