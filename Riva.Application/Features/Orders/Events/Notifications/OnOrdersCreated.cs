using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riva.Application.Features.Orders.Events.Notifications
{
    public class OnOrdersCreated : INotification
    {
        public int NewOrderId { get; private set; }
        public OnOrdersCreated(int newOrderId)
        {
            NewOrderId = newOrderId;
        }
    }
}
