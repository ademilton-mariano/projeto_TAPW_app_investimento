using AdeInvest.Repositorios;
using Plataforma_Investimento_AdeInvest.Models;

namespace AdeInvest.Servicos;

public class UsuarioClienteServico : IUsuarioClienteServico
{
    private readonly IUsuarioClienteRepositorio _repositorio;

    public UsuarioClienteServico(IUsuarioClienteRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public void CadastrarUsuarioCliente(UsuarioCliente usuarioCliente)
    {
        _repositorio.AdicionarUsuarioCliente(usuarioCliente);
    }

    public void AtualizarUsuarioCliente(UsuarioCliente usuarioCliente)
    {
        _repositorio.AtualizarUsuarioCliente(usuarioCliente);
    }

    public void DeletarUsuarioCliente(int id)
    {
        var usuarioCliente = _repositorio.ObterUsuarioClientePorId(id);
        if (usuarioCliente != null)
        {
            _repositorio.DeletarUsuarioCliente(usuarioCliente);
        }
    }

    public List<UsuarioCliente> ObterTodosUsuariosClientes()
    {
        return _repositorio.ObterTodosUsuariosClientes();
    }

    public UsuarioCliente ObterUsuarioClientePorId(int id)
    {
        return _repositorio.ObterUsuarioClientePorId(id);
    }

    public UsuarioCliente ObterUsuarioClientePorEmail(string email)
    {
        return _repositorio.ObterUsuarioClientePorEmail(email);
    }
}