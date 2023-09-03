using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Spring_to_.net.Business.Contracts;
using Project_Spring_to_.net.Data;
using Project_Spring_to_.net.Models;
using Project_Spring_to_.net.Models.DTO;

namespace Project_Spring_to_.net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IClientService _clientService;

        public ClientsController(AppDbContext context, IClientService clientService)
        {
            _context = context;
            _clientService=clientService;
        }

        // GET: api/Clients
        [HttpGet]
        public ActionResult<IEnumerable<ClientDto>> Getclients()
        {
            return Ok(_clientService.Getclients());
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public  ActionResult<Client> GetClient(int id)
        {
            return Ok(_clientService.GetClient(id));
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutClient(int id, ClientDto client)
        {
            _clientService.PutClient(id, client);
            return Ok();
        }

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostClient(ClientDto client)
        {
            _clientService.PostClient(client);
            return Ok();
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            _clientService.DeleteClient(id);
            return Ok();
        }
    }
}
