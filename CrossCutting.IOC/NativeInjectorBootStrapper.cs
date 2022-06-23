using System.Reflection;
using Application.Commands.EstudanteCommands.CadastrarEstudante;
using Infraestrutura.Persistencia;
using Infraestrutura.Repositorios.ContratoRepositorio;
using Infraestrutura.Repositorios.CursoRepositorio;
using Infraestrutura.Repositorios.EstudanteRepositorio;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.IOC;

public class NativeInjectorBootStrapper
{
    public static void RegistrarServicos(IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>();
        services.AddScoped<IEstudanteRepositorio, EstudanteRepositorio>();
        services.AddScoped<ICursoRepositorio, CursoRepositorio>();
        services.AddScoped<IContratoRepositorio, ContratoRepositorio>();
        services.AddMediatR(typeof(CriarEstudanteHandler).GetTypeInfo().Assembly);
    }
}