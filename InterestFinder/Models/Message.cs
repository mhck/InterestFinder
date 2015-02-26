using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterestFinder.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        
        [Required, DisplayName("Message")]
        public string Content { get; set; }

        [DisplayName("To (E-mail)")]
        public string ReceiverName { get; set; }
        
        [DisplayName("From")]
        public string SenderName { get; set; } 
        
        public ApplicationUser Receiver { get; set; }
        
        [DisplayName("Date")]
        public DateTime TimeSent { get; set; }
        
        public ICollection<string> Tags { get; set; }
    }
}