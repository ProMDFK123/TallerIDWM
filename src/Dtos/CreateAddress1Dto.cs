using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.src.Dtos
{
    public class CreateAddres1Dto
    {
        public required string Street { get; set; }
        public required string Number { get; set; }
        public required string Commune { get; set; }
        public required string Region { get; set; }
        public required string PostalCode { get; set; }
    }
}