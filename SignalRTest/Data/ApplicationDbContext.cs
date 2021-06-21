using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SignalRTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRTest.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Message>().
                HasOne<AppUser>(a => a.Sender).
                WithMany(d => d.Messages).
                HasForeignKey(d => d.UserId);
        }
        public virtual DbSet<Message> messages { get; set; }
    }
}
