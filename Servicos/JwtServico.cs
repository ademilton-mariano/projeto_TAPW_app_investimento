using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Plataforma_Investimento_AdeInvest.Models;

namespace AdeInvest.Servicos;

public class JwtServico
{
    private readonly Configuracoes? _configuracoes;
    private readonly IConfiguration _configuration;

    public JwtServico(IConfiguration configuration)
    {
        _configuration = configuration;
        _configuracoes = configuration.GetSection("Configuracoes").Get<Configuracoes>();
    }

    public string GenerateToken(UsuarioCliente usuarioCliente)
    {
        var xTokenHandler = new JwtSecurityTokenHandler();
        var xChave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuracoes.ChaveJwt));
        var xCredencais = new SigningCredentials(xChave, SecurityAlgorithms.HmacSha256Signature);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, usuarioCliente.Id.ToString()),
            new Claim(ClaimTypes.Email, usuarioCliente.Email),
        };

        var xToken = new JwtSecurityToken(
            _configuracoes.Emissor,
            _configuracoes.Emissor,
            claims,
            expires: DateTime.Now.AddMinutes(_configuracoes.Expiracao),
            signingCredentials: xCredencais
        );

        return xTokenHandler.WriteToken(xToken);
    }
}