using EstudosDocker.domain;
using EstudosDocker.services.interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;

namespace EstudosDocker.services.services
{
    public class MessageService : IMessageService
    {
        private ConnectionFactory _factory;
        private IConnection _conn;
        private IModel _channel;

        public MessageService()
        {
            Console.WriteLine("about to connect to rabbit");

            _factory = new ConnectionFactory() { HostName = "rabbitmq", Port = 5672 };
            _factory.DispatchConsumersAsync = true;
            _factory.NetworkRecoveryInterval = TimeSpan.FromSeconds(10);
            _factory.UserName = "admin";
            _factory.Password = "Livros123Estudos";
            _conn = _factory.CreateConnection();
            _channel = _conn.CreateModel();
            _channel.QueueDeclare(queue: "keylivros",
                                    durable: true,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);
        }

        public async Task<bool> Enqueue(LivroDto livro, CancellationToken ct)
        {
            var livroJson = JsonSerializer.Serialize(livro);
            
            var body = Encoding.UTF8.GetBytes(livroJson);

            IBasicProperties props = _channel.CreateBasicProperties();
            props.ContentType = "text/plain";
            props.DeliveryMode = 2;
            props.Expiration = "36000000";

            _channel.BasicPublish(exchange: "exchangelivros",
                                routingKey: "keylivros",
                                basicProperties: props,
                                body: body);
            
            Console.WriteLine(" [x] Published {0} to RabbitMQ", livroJson);
            
            return true;
        }
    }
}