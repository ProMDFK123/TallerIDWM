using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using api.src.Data;
using api.src.Interfaces;
using api.src.Models;

using Microsoft.EntityFrameworkCore;

namespace api.src.Repositories
{
    public class Address1Repository(DataContext context) : IAddress1Repository
    {
        private readonly DataContext _context = context;

        public async Task<Address1?> GetByUserIdAsync(string userId)
        {
            return await _context.Address1s
                .FirstOrDefaultAsync(a => a.UserId == userId);
        }

        public async Task AddAsync(Address1 address)
        {
            await _context.Address1s.AddAsync(address);
        }

        public async Task<Address1> GetDefaultAddressAsync(string userId)
        {
            return await _context.Address1s
                .Where(a => a.UserId == userId)
                .FirstOrDefaultAsync(a => a.UserId == userId && a.IsDefault);
        }
    }
}