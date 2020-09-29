using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KocFinans.NotificationWorker
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var uri = new Uri("amqps://zfrhbxtn:vriC8Xsdn-BoatUvxSK5KFSPevFInLLn@sparrow.rmq.cloudamqp.com/zfrhbxtn");

                var factory = new ConnectionFactory
               {
                    Uri = uri,
                };

                var connection = factory.CreateConnection();

                var channel = connection.CreateModel();




                channel.BasicQos(0, 1, false);

                MessageReceiver messageReceiver = new MessageReceiver(channel);

                channel.BasicConsume("CreditNotification", true, messageReceiver);
                connection.Close();
                Thread.Sleep(20000);
            }


 
        }
    }
}
