using System.Reflection;
using Application.Commands.EstudanteCommands.CadastrarEstudante;
using Infraestrutura.Persistencia;
using Infraestrutura.Repositorios.ContratoRepositorio;
using Infraestrutura.Repositorios.CursoRepositorio;
using Infraestrutura.Repositorios.EstudanteRepositorio;
using MediatR;
using Servicos;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>(); //ToDo: CRIAR CAMADA IOC
        services.AddDbContext<ApplicationDbContext>();
        services.AddScoped<IEstudanteRepositorio, EstudanteRepositorio>();
        services.AddScoped<ICursoRepositorio, CursoRepositorio>();
        services.AddScoped<IContratoRepositorio, ContratoRepositorio>();
        services.AddMediatR(typeof(CriarEstudanteHandler).GetTypeInfo().Assembly);
    })
    .Build();

await host.RunAsync();