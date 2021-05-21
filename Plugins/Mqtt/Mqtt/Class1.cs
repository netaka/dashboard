using System;
using System.Threading;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;

namespace Mqtt
{
    public class Class1
    {
        IMqttClient mqttClient;
        string host;
        public Class1(string host)
        {
            this.host = host;
        }

        public async void Connect()
        {
            var factory = new MqttFactory();
            mqttClient = factory.CreateMqttClient();

            var options = new MqttClientOptionsBuilder()
                .WithTcpServer(this.host)
                .Build();

            mqttClient.UseConnectedHandler(async e =>
            {
                Console.WriteLine("Connected!");
            });
            await mqttClient.ConnectAsync(options, CancellationToken.None);
        }
    }
}
