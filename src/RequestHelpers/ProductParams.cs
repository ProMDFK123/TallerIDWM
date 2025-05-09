using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.src.RequestHelpers
{
    public class ProductParams : PaginationParams
    {
        public string? Search { get; set; }
        public string? OrderBy { get; set; };
        public string? Category { get; set; }
        public string? Brand { get; set; }
    }
}