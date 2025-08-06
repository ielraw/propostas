using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Queue.Interfaces
{
    public interface IMessageBusPublisher
    {
        Task PublishAsync<T>(string queue, T message) where T : class;
    }
}
