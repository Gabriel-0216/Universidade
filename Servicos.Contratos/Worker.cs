using System.Text;
using Application.Commands.ContratoCommands;
using MediatR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
namespace Servicos;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly IMediator _mediator;

    public Worker(ILogger<Worker> logger, IServiceScopeFactory serviceScopeFactory, IMediator mediator)
    {
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;
        _mediator = mediator;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var servidor = new ConnectionFactory()
            {HostName = "localhost", Port = 5672, UserName = "gnascimento", Password = "gnascimento"};
        var conexao = servidor.CreateConnection();
        {
            using var canal = conexao.CreateModel();
            {
                canal.QueueDeclare(queue: "contratosv1",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);
                
                var consumidor = new EventingBasicConsumer(canal);
                
                canal.BasicConsume(queue: "contratosv1",
                    autoAck: true,
                    consumer: consumidor);

                consumidor.Received += async (model, ea) =>
                {
                    Console.WriteLine("Mensagem recebida!");
                    var corpo = ea.Body.ToArray();
                    var mensagem = Encoding.UTF8.GetString(corpo);
                    var objetoSerializado = JsonConvert.DeserializeObject<GerarContratoCommand>(mensagem);
                    var enviar = await _mediator.Send(objetoSerializado);
                };

                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    await Task.Delay(1000, stoppingToken);
                }
            }
        }
       
    }
    private void Consumer_Received(
        object sender, BasicDeliverEventArgs e)
    {
        _logger.LogInformation(
            $"[Nova mensagem | {DateTime.Now:yyyy-MM-dd HH:mm:ss}] " +
            Encoding.UTF8.GetString(e.Body.ToArray()));
    }
}