using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riva.Application.Features.Products.Events.Notifications
{
    public class OnProductCreated : INotification
    {
        public int NewProductID { get; private set; }
        public OnProductCreated(int newProductId)
        {
            NewProductID = newProductId;
        }
    }
}
