using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRTest.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        [Required]
        [StringLength(4096, MinimumLength = 1)]
        public string Text { get; set; }
        public DateTime When { get; set; }
        public String UserId { get; set; }
        public virtual AppUser Sender { get; set; }
    }
}
