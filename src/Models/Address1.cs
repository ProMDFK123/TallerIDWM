using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace api.src.Models
{
    public class Address1
    {
        public int Id { get; set; }
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string commune { get; set; }
        public required string Region { get; set; }
        public required string postalCode { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}