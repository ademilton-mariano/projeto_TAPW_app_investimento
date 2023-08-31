using AdeInvest.BancoDados;
using AdeInvest.Repositorios;
using AdeInvest.Servicos;

var builder = WebApplication.CreateBuilder(args);

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

