using AdeInvest.BancoDados;
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
            DataNascimento = usuarioCliente.DataNascimento,
        };
        _dados.UsuarioCliente.Add(xUsuarioCliente);
        _dados.SaveChanges();
    }

    public void AtualizarUsuarioCliente(UsuarioCliente usuarioCliente)
    {
        _dados.Entry(usuarioCliente).State = EntityState.Modified;
        _dados.SaveChanges();
    }

    public void DeletarUsuarioCliente(int id)
    {
        var xUsuarioCliente = _dados.UsuarioCliente.FirstOrDefault(u => u.Id == id);

        if (xUsuarioCliente == null)
        {
            return;
        }

        _dados.UsuarioCliente.Remove(xUsuarioCliente);
        _dados.SaveChanges();
    }

    public List<UsuarioClienteViewModel> ObterTodosUsuariosClientes()
    {
        return _dados.UsuarioCliente.Cast<UsuarioClienteViewModel>().ToList();
    }

    public UsuarioClienteViewModel ObterUsuarioClientePorId(int id)
    {
        var xUsuarioCliente = _dados.UsuarioCliente.FirstOrDefault(u => u.Id == id);

        if (xUsuarioCliente == null)
        {
            return null;
        }

        return  new UsuarioClienteViewModel
        {
           Id = xUsuarioCliente.Id
           , Cpf = xUsuarioCliente.Cpf
           , DataNascimento = xUsuarioCliente.DataNascimento
           , Email = xUsuarioCliente.Email
           , DataLogin = xUsuarioCliente.DataLogin
           , Nome = xUsuarioCliente.Nome
        };
    }

    public UsuarioCliente ObterUsuarioClientePorEmail(string email)
    {
        return _dados.UsuarioCliente.FirstOrDefault(u => u.Email == email);
    }

    public void AtualizarDataUltimoLogin(UsuarioCliente usuarioCliente, DateTime login)
    {
        usuarioCliente.DataLogin = login;
        _dados.Entry(usuarioCliente).State = EntityState.Modified;
        _dados.SaveChanges();
    }
}