
using KocFinans.Public.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KocFinans.Gateway.Service
{
    public class MessagingService {
        private readonly ConnectionFactory _connectionFactory;
        private IConnection _connection;
        protected IModel Channel { get; private set; }
        public MessagingService(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            ConnectToRabbitMq();

        }
        private void ConnectToRabbitMq()
        {
            if (_connection == null || _connection.IsOpen == false)
            {
                _connection = _connectionFactory.CreateConnection();
            }

            if (Channel == null || Channel.IsOpen == false)
            {
                Channel = _connection.CreateModel();

                Channel.QueueDeclare(
                    queue: "CreditNotification",
                    durable: false,
                    exclusive: false,
                    autoDelete: false);

            }
        }
        public  void QueueMessage(Credit credit)
        {
            var message = credit;
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            Channel.BasicPublish("", "CreditNotification", null, body);
            _connection.Close();
        }
    }
}
