using Azure.Messaging.ServiceBus;
using Cooperativa.Infraestructura.API.SBPublisher.Interfaces;
using Cooperativa.Infraestructura.ServiceBus.Eventos;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cooperativa.Infraestructura.API.SBPublisher
{
    public class EventPublisher : IEventPublisher
    {

        const string ServiceBusConnectionString = "Endpoint=sb://sb-cooperativa.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=uQejf4ET8WE1vk7K51iQJeKiPr96N7vFs5TToFB2vBk=";
        const string EventQueue = "eventqueue";
        const string ResultQueue = "resultqueue";

        public async Task<EventoCola> PublicarEvento(EventoCola evento)
        {
            await using var client = new ServiceBusClient(ServiceBusConnectionString);
            await using ServiceBusSender sender = client.CreateSender(EventQueue);

            try
            {
                var message = new ServiceBusMessage(JsonSerializer.SerializeToUtf8Bytes(evento))
                {
                    ContentType = "application/json",
                    ReplyTo = ResultQueue,
                };

                await sender.SendMessageAsync(message);

                ServiceBusReceiver receiver = client.CreateReceiver(ResultQueue);

                ServiceBusReceivedMessage replyMessage = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(60));

                if (replyMessage == null)
                {
                    throw new ArgumentNullException("Publisher: Didn't receive a response.");
                }

                await receiver.CompleteMessageAsync(replyMessage);

                return JsonSerializer.Deserialize<EventoCola>(replyMessage.Body.ToString());
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
            }
            return null;
        }
    }
}
