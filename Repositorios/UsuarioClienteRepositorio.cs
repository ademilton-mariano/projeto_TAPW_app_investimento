using AdeInvest.BancoDados;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Plataforma_Investimento_AdeInvest.Models;
using SecureIdentity.Password;

namespace AdeInvest.Repositorios;

public class UsuarioClienteRepositorio : IUsuarioClienteRepositorio
{
    private readonly Dados _dados;

    public UsuarioClienteRepositorio(Dados dados)
    {
        _dados = dados;
    }

    public void AdicionarUsuarioCliente(UsuarioCliente usuarioCliente)
    {
        var xUsuarioCliente = new UsuarioCliente
        {
            Nome = usuarioCliente.Nome,
            Email = usuarioCliente.Email,
            Senha = PasswordHasher.Hash(usuarioCliente.Senha),
            Cpf = usuarioCliente.Cpf,
        };
        _dados.UsuarioCliente.Add(xUsuarioCliente);
        _dados.SaveChanges();
    }

    public void AtualizarUsuarioCliente(UsuarioCliente usuarioCliente)
    {
        _dados.Entry(usuarioCliente).State = EntityState.Modified;
        _dados.SaveChanges();
    }

    public void DeletarUsuarioCliente(UsuarioCliente usuarioCliente)
    {
        _dados.UsuarioCliente.Remove(usuarioCliente);
        _dados.SaveChanges();
    }

    public List<UsuarioCliente> ObterTodosUsuariosClientes()
    {
        return _dados.UsuarioCliente.ToList();
    }

    public UsuarioCliente ObterUsuarioClientePorId(int id)
    {
        return _dados.UsuarioCliente.FirstOrDefault(u => u.Id == id);
    }

    public UsuarioCliente ObterUsuarioClientePorEmail(string email)
    {
        return _dados.UsuarioCliente.FirstOrDefault(u => u.Email == email);
    }
}