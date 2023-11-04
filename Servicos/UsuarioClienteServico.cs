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

    public UsuarioCliente CadastrarUsuarioCliente(UsuarioCliente usuarioCliente)
    {
        return _repositorio.AdicionarUsuarioCliente(usuarioCliente);
        
    }

    public void AtualizarUsuarioCliente(UsuarioCliente usuarioCliente)
    {
        _repositorio.AtualizarUsuarioCliente(usuarioCliente);
    }

    public void DeletarUsuarioCliente(int id)
    {
            _repositorio.DeletarUsuarioCliente(id);
    }

    public List<UsuarioClienteViewModel> ObterTodosUsuariosClientes()
    {
        return _repositorio.ObterTodosUsuariosClientes();
    }

    public UsuarioClienteViewModel ObterUsuarioClientePorId(int id)
    {
        return _repositorio.ObterUsuarioClientePorId(id);
    }

    public UsuarioCliente ObterUsuarioClientePorEmail(string email)
    {
        return _repositorio.ObterUsuarioClientePorEmail(email);
    }

    public void AtualizarDataUltimoLogin(UsuarioCliente usuarioCliente, DateTime login)
    {
        _repositorio.AtualizarDataUltimoLogin(usuarioCliente, login);
    }
}