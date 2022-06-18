using System.Reflection;
using Application.Commands.EstudanteCommands.CadastrarEstudante;
using Infraestrutura.Persistencia;
using Infraestrutura.Repositorios.CursoRepositorio;
using Infraestrutura.Repositorios.EstudanteRepositorio;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<IEstudanteRepositorio, EstudanteRepositorio>();
builder.Services.AddScoped<ICursoRepositorio, CursoRepositorio>();
builder.Services.AddMediatR(typeof(CriarEstudanteHandler).GetTypeInfo().Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();