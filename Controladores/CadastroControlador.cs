using AdeInvest.Servicos;
using Microsoft.AspNetCore.Mvc;
using Plataforma_Investimento_AdeInvest.Models;

namespace AdeInvest.Controladores;

[Route("cadastro")]
public class CadastroControlador : ControllerBase
{
    private readonly IUsuarioClienteServico _usuarioClienteServico;
    private readonly IContaServico _contaServico;
    private readonly IInvestimentoServico _investimentoServico;

    public CadastroControlador(IUsuarioClienteServico usuarioClienteServico, IContaServico contaServico, IInvestimentoServico investimentoServico)
    {
        _usuarioClienteServico = usuarioClienteServico;
        _contaServico = contaServico;
        _investimentoServico = investimentoServico;
    }

    [HttpPost("")]
    public IActionResult Cadastrar([FromBody] CadastroViewModel cadastro)
    {
        try
        {
            var xUsuario = new UsuarioCliente
            {
                Nome = cadastro.Nome,
                Email = cadastro.Email,
                Senha = cadastro.Senha,
                DataNascimento = cadastro.DataNascimento,
                Cpf = cadastro.Cpf.Substring(0,11),
            };
            var xNovoUsuario = _usuarioClienteServico.CadastrarUsuarioCliente(xUsuario);
            var xInvestimento = _investimentoServico.ObterInvestimentoPorId(cadastro.IdInvestimento);

            if ( xInvestimento == null)
            {
                return NotFound("Investimento não encontrado");
            }

            var xConta = new Conta
            {
                UsuarioCliente = xNovoUsuario,
                Investimento = xInvestimento,
                Saldo = cadastro.Saldo,
                CriadoDataHora = DateTime.UtcNow,
                Ativo = true
            };
            _contaServico.AdicionarConta(xConta);
            return Ok("Cadastro realizado com sucesso");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPut("{id:int}")]
    public IActionResult AtualizarUsuarioCliente(int id, [FromBody] UsuarioCliente usuarioCliente)
    {
        var usuarioExistente = _usuarioClienteServico.ObterUsuarioClientePorId(id);
        if (usuarioExistente == null)
        {
            return NotFound("Usuário não encontrado");
        }

        _usuarioClienteServico.AtualizarUsuarioCliente(usuarioCliente);
        return Ok("Usuário atualizado com sucesso");
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeletarUsuarioCliente(int id)
    {
        var usuarioExistente = _usuarioClienteServico.ObterUsuarioClientePorId(id);
        if (usuarioExistente == null)
        {
            return NotFound("Usuário não encontrado");
        }

        _usuarioClienteServico.DeletarUsuarioCliente(id);
        return Ok("Usuário deletado com sucesso");
    }

    [HttpGet("")]
    public IActionResult ObterTodosUsuariosClientes()
    {
        var usuariosClientes = _usuarioClienteServico.ObterTodosUsuariosClientes();
        return Ok(usuariosClientes);
    }

    [HttpGet("{id:int}")]
    public IActionResult ObterUsuarioClientePorId(int id)
    {
        var usuarioCliente = _usuarioClienteServico.ObterUsuarioClientePorId(id);
        if (usuarioCliente == null)
        {
            return NotFound("Usuário não encontrado");
        }

        return Ok(usuarioCliente);
    }
}