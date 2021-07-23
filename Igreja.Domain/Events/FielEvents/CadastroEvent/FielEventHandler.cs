using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Igreja.Domain.Events.FielEvents.CadastroEvent
{
    public class FielEventHandler : INotificationHandler<FielCadastradoEvent>
    {
        public Task Handle(FielCadastradoEvent notification, CancellationToken cancellationToken)
        {
            //Enviar Email
            return Task.CompletedTask;
        }
    }
}
