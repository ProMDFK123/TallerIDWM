using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api.src.Dtos
{
    public class ToggleStatusDto
    {
        [StringLength(255)]
        public string? Reason { get; set; }
    }
}