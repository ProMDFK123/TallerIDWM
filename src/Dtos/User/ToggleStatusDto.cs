using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.src.Dtos
{
    public class ToggleStatusDto
    {
        [StringLength(255)]
        public string? Reason { get; set; }
    }
}