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
    public class PurchasesController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchasesController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        // GET: api/Purchase
        [HttpGet]
        public ActionResult<IEnumerable<PurchaseDto>> GetPurchases()
        {
            return Ok(_purchaseService.GetPurchases());
        }

        // GET: api/Purchase/5
        [HttpGet("{id}")]
        public ActionResult<PurchaseDto> GetClient(int id)
        {
            return Ok(_purchaseService.GetPurchase(id));
        }

        // PUT: api/Purchase/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutClient(int id, PurchaseDto purchase)
        {
            _purchaseService.PutPurchase(id, purchase);
            return Ok();
        }

        // POST: api/Purchase
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostClient(PurchaseDto purchase)
        {
            _purchaseService.PostPurchase(purchase);
            return Ok();
        }

        // DELETE: api/Purchase/5
        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            _purchaseService.DeletePurchase(id);
            return Ok();
        }
    }
}
