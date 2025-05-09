using api.src.Data;
using api.src.Interfaces;
using api.src.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_web_api.Src.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Address1Controller(IAddress1Repository address1Repository, UnitOfWork unitOfWork) : ControllerBase
    {
        private readonly UnitOfWork _context = unitOfWork;
        private readonly IAddress1Repository _address1Repository = address1Repository;


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address1>>> GetAddresses()
        {
            var addresses = await _address1Repository.GetAddresses();
            return Ok(addresses);
        }

        // GET: api/Address1/5
        // Obtiene una dirección por su ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Address1>> GetAddress(int id)
        {
            var address = await _address1Repository.GetAddressById(id);

            if (address == null)
                return NotFound();

            return Ok(address);
        }
    }
}