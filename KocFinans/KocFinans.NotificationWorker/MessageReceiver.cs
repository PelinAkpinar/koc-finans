using KocFinans.Public.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace KocFinans.NotificationWorker
{
    public class MessageReceiver : DefaultBasicConsumer

    {

        private readonly IModel _channel;

        public MessageReceiver(IModel channel)

        {

            _channel = channel;

        }
      public override void HandleBasicDeliver(string consumerTag,
            ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, ReadOnlyMemory<byte> body)

        {

            Console.WriteLine($"Consuming Message");

            //Console.WriteLine(string.Concat("Message received from the exchange ", exchange));

            //Console.WriteLine(string.Concat("Consumer tag: ", consumerTag));

            //Console.WriteLine(string.Concat("Delivery tag: ", deliveryTag));

            //Console.WriteLine(string.Concat("Routing tag: ", routingKey));

            //Console.WriteLine(string.Concat("Message: ", Encoding.UTF8.GetString(body.ToArray())));
            var bodyArr = body.ToArray();
            var message = Encoding.UTF8.GetString(bodyArr);
            var obj = JsonConvert.DeserializeObject<Credit>(message);
            Console.WriteLine(string.Format("Sayin {0} {1}, {2} basvuru numarali,{3} limitli  krediniz onaylanmistir."
            , obj.Name, obj.Surname, obj.Id, obj.CreditAmount));
            //_channel.BasicAck(deliveryTag, false);

        }

    }
}
