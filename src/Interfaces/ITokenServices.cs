using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.src.Models;

namespace api.src.Interfaces
{
    public interface ITokenServices
    {
        string GenerateToken(User user, string role);
    }
}