using EstudosDockerServicoTheWork.Dominio;
using EstudosDockerServicoTheWork.Infra.Interface;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace EstudosDockerServicoTheWork.Services
{
    internal class MessageService : IMessageService
    {
        private ConnectionFactory _factory;
        private IConnection _conn;
        private IModel _channel;
        private readonly ILivroRepository _repository;

        public MessageService(ILivroRepository repository)
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
            _repository = repository;
        }

        public void Enqueue()
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();  // Obtém o corpo da mensagem como um array de bytes
                var message = Encoding.UTF8.GetString(body);  // Converte para string (JSON)

                // Desserializa o JSON de volta para o objeto LivroDto
                var livro = JsonSerializer.Deserialize<LivroDto>(message);

                if (livro != null)
                    await _repository.GravarLivro(livro);
            };

            _channel.BasicConsume(queue: "hello",
                                  autoAck: true,
                                  consumer: consumer);
        }
    }
}