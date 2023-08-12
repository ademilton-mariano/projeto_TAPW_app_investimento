using AdeInvest.BancoDados;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Plataforma_Investimento_AdeInvest.Models;
using SecureIdentity.Password;

namespace AdeInvest.Contoladores;

public class UsuarioClienteControlador : ControllerBase
{
    [HttpPost("usuario-cliente")]
    public IActionResult CadastraUsuarioCliente([FromBody] UsuarioCliente pUsuarioCliente,
        [FromRoute] int pId, 
        [FromServices] Dados dados)
    {
        try
        {
            var xUsuarioCliente= new UsuarioCliente
            {
                Nome = pUsuarioCliente.Nome,
                Usuario = pUsuarioCliente.Usuario,
                Senha = PasswordHasher.Hash(pUsuarioCliente.Senha),
                Cpf = pUsuarioCliente.Cpf,
                Email = pUsuarioCliente.Email
            };
            
            dados.UsuarioCliente.Add(xUsuarioCliente);
            dados.SaveChanges();
            return Created($"usuario-cliente/{pId}", "Criado com Sucesso");
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, "Não foi possível adicionar a tarefa");
        }
        catch
        {
            return StatusCode(500, "Falha interna no servidor");
        }
    }
}