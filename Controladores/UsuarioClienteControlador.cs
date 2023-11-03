using AdeInvest.Servicos;
using Microsoft.AspNetCore.Mvc;
using Plataforma_Investimento_AdeInvest.Models;

namespace AdeInvest.Contoladores;

public class UsuarioClienteControlador : ControllerBase
{
    private readonly IUsuarioClienteServico _servico;

    public UsuarioClienteControlador(IUsuarioClienteServico servico)
    {
        _servico = servico;
    }

    [HttpPost("usuario-cadastrar")]
    public IActionResult CadastrarUsuarioCliente([FromBody] UsuarioCliente usuarioCliente)
    {
        try
        {
            _servico.CadastrarUsuarioCliente(usuarioCliente);
            return Ok("Usuário cadastrado com sucesso");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPut("usuario-atualizar/{id}")]
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

    [HttpDelete("usuario-deletar/{id}")]
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

    [HttpGet("usuario-todos")]
    public IActionResult ObterTodosUsuariosClientes()
    {
        var usuariosClientes = _servico.ObterTodosUsuariosClientes();
        return Ok(usuariosClientes);
    }

    [HttpGet("usuario-{id:int}")]
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