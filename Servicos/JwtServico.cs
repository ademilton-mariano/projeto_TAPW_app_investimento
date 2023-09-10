using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Plataforma_Investimento_AdeInvest.Models;

namespace AdeInvest.Servicos;

public class JwtServico
{
    public string GenerateToken(UsuarioCliente usuarioCliente)
    {
        var xChave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuracoes.ChaveJwt));
        var xCredencais = new SigningCredentials(xChave, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, usuarioCliente.Id.ToString()),
            new Claim(ClaimTypes.Email, usuarioCliente.Email),
            // Você pode adicionar outras informações personalizadas aqui, como roles (funções) do usuário
        };

        var token = new JwtSecurityToken(
            Configuracoes.Emissor,
            Configuracoes.Emissor,
            claims,
            expires: DateTime.Now.AddMinutes(Configuracoes.Expiracao),
            signingCredentials: xCredencais
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}