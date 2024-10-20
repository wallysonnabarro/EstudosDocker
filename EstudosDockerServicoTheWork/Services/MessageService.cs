using EstudosDockerServicoTheWork.Dominio;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;

namespace EstudosDockerServicoTheWork.Services
{
    internal class MessageService : IMessageService
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
        public void Enqueue()
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();  // Obtém o corpo da mensagem como um array de bytes
                var message = Encoding.UTF8.GetString(body);  // Converte para string (JSON)

                // Desserializa o JSON de volta para o objeto LivroDto
                var livro = JsonSerializer.Deserialize<LivroDto>(message);

                // Agora você pode usar o objeto livro da forma que precisar
                Console.WriteLine(" [x] Received from Rabbit: {0}", message);
                Console.WriteLine(" [x] Processed Livro: {0}", livro.Titulo);  // Exemplo de uso do objeto livro
            };

            _channel.BasicConsume(queue: "hello",
                                  autoAck: true,
                                  consumer: consumer);
        }
    }
}