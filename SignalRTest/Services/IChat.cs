using SignalRTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRTest.Services
{
    public interface IChat
    {
        Task AddMessage(Message message);
        IQueryable<Message> GetMessageses();
    }
}
