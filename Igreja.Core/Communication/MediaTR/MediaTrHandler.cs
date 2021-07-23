using Igreja.Core.Messages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Core.Communication.MediaTR
{
    public class MediaTrHandler : IMediatrHandler
    {
        private readonly IMediator _mediaTr;

        public MediaTrHandler(IMediator mediaTr)
        {
            _mediaTr = mediaTr;
        }
        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            await _mediaTr.Publish(evento);
        }
    }
}
