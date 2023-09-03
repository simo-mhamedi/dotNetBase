using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project_Spring_to_.net.Business.Contracts;
using Project_Spring_to_.net.Data;
using Project_Spring_to_.net.Models.DTO;
using Project_Spring_to_.net.Models;

namespace Project_Spring_to_.net.Business
{
    public class ClientCategoryService : IClientCategoryService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ClientCategoryService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ClientCategoryDto> GetClientCategorys()
        {
            if (_context.clientCategories == null)
            {
                throw new ApplicationException("not found");
            }
            return _mapper.Map<IEnumerable<ClientCategoryDto>>(_context.clientCategories.ToList());
        }

        public ClientCategoryDto GetClientCategory(int id)
        {
            var client = _context.clientCategories.FirstOrDefault(c => c.Id == id);

            if (client == null)
            {
                throw new ApplicationException("not found");
            }

            return _mapper.Map<ClientCategoryDto>(client);
        }

        public void PutClientCategory(int id, ClientCategoryDto client)
        {
            if (!ClientCategoryExists(id))
            {
                throw new ApplicationException("not found");
            }
            ClientCategory updatedClient = _mapper.Map<ClientCategory>(client);
            _context.Entry(updatedClient).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void PostClientCategory(ClientCategoryDto client)
        {
            if (ClientCategoryExists(client.Id))
            {
                throw new ApplicationException("Already exist");
            }
            ClientCategory savedClient = _mapper.Map<ClientCategory>(client);
            _context.clientCategories.Add(savedClient);
            _context.SaveChanges();
        }

        public void DeleteClientCategory(int id)
        {
            if (!ClientCategoryExists(id))
            {
                throw new ApplicationException("not found");
            }
            var client = _context.clients.FirstOrDefault(c => c.Id == id);
            ClientCategory removedClient = _mapper.Map<ClientCategory>(client);

            _context.clientCategories.Remove(removedClient);
            _context.SaveChanges();
        }

        private bool ClientCategoryExists(int id)
        {
            return (_context.clientCategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
