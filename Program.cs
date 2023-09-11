using System.Text;
using AdeInvest;
using AdeInvest.BancoDados;
using AdeInvest.Repositorios;
using AdeInvest.Servicos;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;



var builder = WebApplication.CreateBuilder(args);

var xConfiguracoes = builder.Configuration.GetSection("Configuracoes").Get<Configuracoes>();


var key = Encoding.ASCII.GetBytes(xConfiguracoes.ChaveJwt);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidIssuer = xConfiguracoes.Emissor,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddScoped<IUsuarioClienteRepositorio, UsuarioClienteRepositorio>();
builder.Services.AddScoped<IContaRepositorio, ContaRepositorio>();
builder.Services.AddScoped<IMovimentacaoRepositorio, MovimentacaoRepositorio>();
builder.Services.AddScoped<IInvestimentoRepositorio, InvestimentoRepositorio>();

builder.Services.AddScoped<IUsuarioClienteServico, UsuarioClienteServico>();
builder.Services.AddScoped<IContaServico, ContaServico>();
builder.Services.AddScoped<IMovimentacaoServico, MovimentacaoServico>();
builder.Services.AddScoped<IInvestimentoServico, InvestimentoServico>();


builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddDbContext<Dados>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<JwtServico>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

