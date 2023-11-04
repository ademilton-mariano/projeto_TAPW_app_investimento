using AdeInvest.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace AdeInvest.Controladores;

[ApiController]
[Route("investimento")]
public class InvestimentoControlador : ControllerBase
{
    private readonly IInvestimentoServico _service;

    public InvestimentoControlador(IInvestimentoServico service)
    {
        _service = service;
    }

    [HttpGet("")]
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