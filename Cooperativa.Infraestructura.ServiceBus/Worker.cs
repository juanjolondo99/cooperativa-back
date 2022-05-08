using Azure.Messaging.ServiceBus;
using Cooperativa.Aplicaciones.Servicios;
using Cooperativa.Infraestructura.Datos.Contextos;
using Cooperativa.Infraestructura.Datos.Repositorios;
using Cooperativa.Infraestructura.ServiceBus.Eventos;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Cooperativa.Infraestructura.ServiceBus
{
    public class Worker : BackgroundService
    {

        const string ServiceBusConnectionString = "Endpoint=sb://sb-cooperativa.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=uQejf4ET8WE1vk7K51iQJeKiPr96N7vFs5TToFB2vBk=";
        const string EventQueue = "eventqueue";

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Worker ejecutando");
            while (!stoppingToken.IsCancellationRequested)
            {
                await using var client = new ServiceBusClient(ServiceBusConnectionString);
                var processorOptions = new ServiceBusProcessorOptions
                {
                    MaxConcurrentCalls = 1,
                    AutoCompleteMessages = false
                };

                Console.WriteLine("Creando procesador");
                await using ServiceBusProcessor processor = client.CreateProcessor(EventQueue, processorOptions);
                Console.WriteLine("Procesador creado");

                processor.ProcessMessageAsync += async args =>
                {
                    EventoCola evento = JsonSerializer.Deserialize<EventoCola>(args.Message.Body.ToString());

                    Console.WriteLine($"Procesando evento tipo: {evento.tipo}");

                    switch (evento.tipo)
                    {
                        case "VerAsociados":
                            var asociadosList = CrearAsociadoServicio().Listar();

                            evento.asociados = asociadosList;
                            break;

                        case "VerSaldos":
                            var productosList = CrearProductoServicio().ListarPorAsociadoId(evento.asociadoId);

                            evento.saldos = productosList;
                            break;

                        case "VerMovimientos":
                            var movimientosList = CrearMovimientoServicio().ListarPorAsociadoIdYProductoId(evento.asociadoId, evento.productoId);

                            evento.movimientos = movimientosList;
                            break;

                        default:
                            Console.WriteLine("Tipo de evento no válido");
                            break;
                    }

                    Console.WriteLine("Enviando respuesta a la cola");

                    ServiceBusSender sender = client.CreateSender(args.Message.ReplyTo);
                    ServiceBusMessage replyMessage = new ServiceBusMessage(JsonSerializer.SerializeToUtf8Bytes(evento));
                    await sender.SendMessageAsync(replyMessage);

                    Console.WriteLine("Respuesta enviada");

                    await args.CompleteMessageAsync(args.Message);
                };

                processor.ProcessErrorAsync += ErrorHandler;

                await processor.StartProcessingAsync();

                Task.Delay(2 * 1000).Wait();

                await processor.StopProcessingAsync();
            }

        }

        // handle any errors when receiving messages
        static Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }

        private AsociadoServicio CrearAsociadoServicio()
        {
            CooperativaContexto db = new CooperativaContexto();
            AsociadoRepositorio repo = new AsociadoRepositorio(db);
            AsociadoServicio servicio = new AsociadoServicio(repo);
            return servicio;
        }

        private ProductoServicio CrearProductoServicio()
        {
            CooperativaContexto db = new CooperativaContexto();
            ProductoRepositorio repo = new ProductoRepositorio(db);
            ProductoServicio servicio = new ProductoServicio(repo);
            return servicio;
        }

        private MovimientoServicio CrearMovimientoServicio()
        {
            CooperativaContexto db = new CooperativaContexto();
            MovimientoRepositorio repo = new MovimientoRepositorio(db);
            MovimientoServicio servicio = new MovimientoServicio(repo);
            return servicio;
        }
    }
}
