using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FluffyBot.DataService.Models
{
    public class PhoneNumber
    {
        [Key]
        public Guid Id { get; set; }

        [Phone]
        [MaxLength(32)]
        public string Phone { get; set; }

        public Guid CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
}