using Cooperativa.Infraestructura.ServiceBus.Eventos;
using System.Threading.Tasks;

namespace Cooperativa.Infraestructura.API.SBPublisher.Interfaces
{
    public interface IEventPublisher
    {
        public Task<EventoCola> PublicarEvento(EventoCola evento);

    }
}
