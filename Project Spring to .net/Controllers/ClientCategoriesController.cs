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
    public class ClientCategoriesController : ControllerBase
    {
        private readonly IClientCategoryService _clientCategoryService;

        public ClientCategoriesController(IClientCategoryService clientCategoryService)
        {
            _clientCategoryService = clientCategoryService;
        }

        // GET: api/ClientCategory
        [HttpGet]
        public ActionResult<IEnumerable<ClientCategoryDto>> Getclients()
        {
            return Ok(_clientCategoryService.GetClientCategorys());
        }

        // GET: api/ClientCategory/5
        [HttpGet("{id}")]
        public ActionResult<ClientCategoryDto> GetClient(int id)
        {
            return Ok(_clientCategoryService.GetClientCategory(id));
        }

        // PUT: api/ClientCategory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutClient(int id, ClientCategoryDto clientCategory)
        {
            _clientCategoryService.PutClientCategory(id, clientCategory);
            return Ok();
        }

        // POST: api/ClientCategory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostClient(ClientCategoryDto clientCategory)
        {
            _clientCategoryService.PostClientCategory(clientCategory);
            return Ok();
        }

        // DELETE: api/ClientCategory/5
        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            _clientCategoryService.DeleteClientCategory(id);
            return Ok();
        }
    }
}
