using System;
using System.ComponentModel.DataAnnotations;

namespace Unwind.Core.Models
{
    public class ConversationItem
    {
        public ConversationItem()
        {
        }

        [Required]
        public string Id { get; set; }

        [Required]
        public string Input { get; set; }
    }
}
