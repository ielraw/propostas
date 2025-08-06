using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Queue.Interfaces
{
    public interface IMessageHandler<in T> where T : class
    {
        Task HandleAsync(T message);
    }
}
