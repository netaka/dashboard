using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using System;
using System.Text;
using System.Threading;

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

            mqttClient.ConnectedHandler = new MqttClientConnectedHandlerDelegate(Connected);
            mqttClient.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(MessageReceived);
            await mqttClient.ConnectAsync(options, CancellationToken.None);
        }

        public async void Connected(MqttClientConnectedEventArgs e)
        {
            Console.WriteLine("Connected");
            await mqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic("test").Build());
        }

        public async void MessageReceived(MqttApplicationMessageReceivedEventArgs e)
        {
            var payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
            Console.WriteLine(payload);
        }
    }
}
