using Microsoft.EntityFrameworkCore;
using SignalRTest.Data;
using SignalRTest.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRTest.Services
{
    public class Chat:IChat
    {
        private readonly ApplicationDbContext _context;

        public Chat(ApplicationDbContext context) => _context = context;

        public async Task AddMessage(Message message)
        {
            await _context.Messages.AddAsync(message);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }
        }

        public IQueryable<Message> GetMessageses() =>
            _context.Messages.Include(m => m.Sender);

    }
}
