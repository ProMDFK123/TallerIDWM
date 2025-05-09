using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.src.RequestHelpers
{
    public class UserParams : PaginationParams
    {
        public string? SearchTerm { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? RegisteredFrom { get; set; }
        public DateTime? RegisteredTo { get; set; }
    }
}