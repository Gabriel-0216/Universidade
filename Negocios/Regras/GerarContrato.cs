using System.Text;
using Negocios.Configuracoes;
using Negocios.Dtos;
using Newtonsoft.Json;
using RabbitMQ.Client;
namespace Negocios.Regras;

public class GerarContrato
{
    public GerarContrato()
    {
        
        
    }
    public bool EnviarMensagem(GeracaoContratoDto contratoDto)
    {
        var servidor = new ConnectionFactory()
        {
            HostName = RabbitConfiguracao.HOST,
            Port = RabbitConfiguracao.PORTA,
            UserName = RabbitConfiguracao.USUARIO,
            Password = RabbitConfiguracao.SENHA,
        };
        var conexao = servidor.CreateConnection();
        {
            using var canal = conexao.CreateModel();
            {
                var corpoMensagem = JsonConvert.SerializeObject(contratoDto);
                var mensagemString = Encoding.UTF8.GetBytes(corpoMensagem);
                canal.BasicPublish(exchange: "",
                    routingKey: RabbitConfiguracao.FILA_CONTRATOS,
                    basicProperties: null,
                    body: mensagemString);
            }
        }
        return true;
    }
}