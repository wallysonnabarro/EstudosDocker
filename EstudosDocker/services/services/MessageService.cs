using EstudosDocker.domain;
using EstudosDocker.services.interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace EstudosDocker.services.services
{
    public class MessageService : IMessageService
    {
        ConnectionFactory _factory;
        IConnection _conn;
        IModel _channel;

        public MessageService()
        {
            Console.WriteLine("about to connect to rabbit");

            _factory = new ConnectionFactory() { HostName = "rabbitmq", Port = 5672 };
            _factory.UserName = "admin";
            _factory.Password = "Livros123Estudos";
            _conn = _factory.CreateConnection();
            _channel = _conn.CreateModel();
            _channel.QueueDeclare(queue: "keylivros",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);
        }

        public async Task<bool> Enqueue(LivroDto livro, CancellationToken ct)
        {
            var livroJson = JsonSerializer.Serialize(livro);
            
            var body = Encoding.UTF8.GetBytes(livroJson);

            _channel.BasicPublish(exchange: "",
                                routingKey: "keylivros",
                                basicProperties: null,
                                body: body);
            
            Console.WriteLine(" [x] Published {0} to RabbitMQ", livroJson);
            
            return true;
        }
    }
}