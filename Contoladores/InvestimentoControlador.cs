using AdeInvest.Servicos;
using Microsoft.AspNetCore.Mvc;
using Plataforma_Investimento_AdeInvest.Models;

namespace AdeInvest.Contoladores;

[ApiController]
[Route("api/[controller]")]
public class InvestimentoControlador : ControllerBase
{
    private readonly IInvestimentoServico _service;

    public InvestimentoControlador(IInvestimentoServico service)
    {
        _service = service;
    }

    [HttpPost("cadastrar")]
    public IActionResult CadastrarInvestimento([FromBody] Investimento investimento)
    {
        _service.AdicionarInvestimento(investimento);
        return Created($"api/investimento/{investimento.Id}", "Investimento Criado com Sucesso");
    }

    [HttpPut("atualizar/{id}")]
    public IActionResult AtualizarInvestimento(int id, [FromBody] Investimento investimento)
    {
        var investimentoExistente = _service.ObterInvestimentoPorId(id);
        if (investimentoExistente == null)
        {
            return NotFound("Investimento não encontrado");
        }

        _service.AtualizarInvestimento(investimento);
        return Ok("Investimento atualizado com sucesso");
    }

    [HttpDelete("deletar/{id}")]
    public IActionResult DeletarInvestimento(int id)
    {
        var investimentoExistente = _service.ObterInvestimentoPorId(id);
        if (investimentoExistente == null)
        {
            return NotFound("Investimento não encontrado");
        }

        _service.DeletarInvestimento(id);
        return Ok("Investimento deletado com sucesso");
    }

    [HttpGet("todos")]
    public IActionResult ObterTodosInvestimentos()
    {
        var investimentos = _service.ObterTodosInvestimentos();
        return Ok(investimentos);
    }

    [HttpGet("{id}")]
    public IActionResult ObterInvestimentoPorId(int id)
    {
        var investimento = _service.ObterInvestimentoPorId(id);
        if (investimento == null)
        {
            return NotFound("Investimento não encontrado");
        }

        return Ok(investimento);
    }
}