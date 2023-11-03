namespace Plataforma_Investimento_AdeInvest.Models
{
    public class UsuarioCliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public DateTime? DataLogin { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}