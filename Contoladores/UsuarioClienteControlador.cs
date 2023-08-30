using AdeInvest.Servicos;
using Microsoft.AspNetCore.Mvc;
using Plataforma_Investimento_AdeInvest.Models;

namespace AdeInvest.Contoladores;

[ApiController]
[Route("api/[controller]")]
public class UsuarioClienteControlador : ControllerBase
{
    private readonly IUsuarioClienteServico _servico;

    public UsuarioClienteControlador(IUsuarioClienteServico servico)
    {
        _servico = servico;
    }

    [HttpPost("cadastrar")]
    public IActionResult CadastrarUsuarioCliente([FromBody] UsuarioCliente usuarioCliente)
    {
        _servico.CadastrarUsuarioCliente(usuarioCliente);
        return Created($"api/usuario-cliente/{usuarioCliente.Id}", "Criado com Sucesso");
    }

    [HttpPut("atualizar/{id}")]
    public IActionResult AtualizarUsuarioCliente(int id, [FromBody] UsuarioCliente usuarioCliente)
    {
        var usuarioExistente = _servico.ObterUsuarioClientePorId(id);
        if (usuarioExistente == null)
        {
            return NotFound("Usuário não encontrado");
        }

        _servico.AtualizarUsuarioCliente(usuarioCliente);
        return Ok("Usuário atualizado com sucesso");
    }

    [HttpDelete("deletar/{id}")]
    public IActionResult DeletarUsuarioCliente(int id)
    {
        var usuarioExistente = _servico.ObterUsuarioClientePorId(id);
        if (usuarioExistente == null)
        {
            return NotFound("Usuário não encontrado");
        }

        _servico.DeletarUsuarioCliente(id);
        return Ok("Usuário deletado com sucesso");
    }

    [HttpGet("todos")]
    public IActionResult ObterTodosUsuariosClientes()
    {
        var usuariosClientes = _servico.ObterTodosUsuariosClientes();
        return Ok(usuariosClientes);
    }

    [HttpGet("{id:int}")]
    public IActionResult ObterUsuarioClientePorId(int id)
    {
        var usuarioCliente = _servico.ObterUsuarioClientePorId(id);
        if (usuarioCliente == null)
        {
            return NotFound("Usuário não encontrado");
        }

        return Ok(usuarioCliente);
    }
}