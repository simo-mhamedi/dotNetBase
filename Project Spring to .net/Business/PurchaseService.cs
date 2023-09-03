using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project_Spring_to_.net.Business.Contracts;
using Project_Spring_to_.net.Data;
using Project_Spring_to_.net.Models.DTO;
using Project_Spring_to_.net.Models;

namespace Project_Spring_to_.net.Business
{
    public class PurchaseService : IPurchaseService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public PurchaseService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<PurchaseDto> GetPurchases()
        {
            if (_context.purchases == null)
            {
                throw new ApplicationException("not found");
            }
            return _mapper.Map<IEnumerable<PurchaseDto>>(_context.purchases.ToList());
        }

        public PurchaseDto GetPurchase(int id)
        {
            var purchase = _context.purchases.FirstOrDefault(c => c.Id == id);

            if (purchase == null)
            {
                throw new ApplicationException("not found");
            }

            return _mapper.Map<PurchaseDto>(purchase);
        }

        public void PutPurchase(int id, PurchaseDto purchase)
        {
            if (!PurchaseExists(id))
            {
                throw new ApplicationException("not found");
            }
            Purchase updatedPurchase = _mapper.Map<Purchase>(purchase);
            _context.Entry(updatedPurchase).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void PostPurchase(PurchaseDto purchase)
        {
            if (PurchaseExists(purchase.Id))
            {
                throw new ApplicationException("Already exist");
            }
            Purchase savedPurchase = _mapper.Map<Purchase>(purchase);
            _context.purchases.Add(savedPurchase);
            _context.SaveChanges();
        }

        public void DeletePurchase(int id)
        {
            if (!PurchaseExists(id))
            {
                throw new ApplicationException("not found");
            }
            var client = _context.clients.FirstOrDefault(c => c.Id == id);
            Purchase removedPurchase = _mapper.Map<Purchase>(client);

            _context.purchases.Remove(removedPurchase);
            _context.SaveChanges();
        }

        private bool PurchaseExists(int id)
        {
            return (_context.purchases?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
