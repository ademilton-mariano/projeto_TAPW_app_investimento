using Plataforma_Investimento_AdeInvest.Models;

namespace AdeInvest.Repositorios;
public interface IUsuarioClienteRepositorio
{
    UsuarioCliente AdicionarUsuarioCliente(UsuarioCliente usuarioCliente);
    void AtualizarUsuarioCliente(UsuarioCliente usuarioCliente);
    void DeletarUsuarioCliente(int id);
    List<UsuarioClienteViewModel> ObterTodosUsuariosClientes();
    UsuarioClienteViewModel ObterUsuarioClientePorId(int id);
    UsuarioCliente ObterUsuarioClientePorEmail(string email);
    void AtualizarDataUltimoLogin(UsuarioCliente usuarioCliente, DateTime login);
}