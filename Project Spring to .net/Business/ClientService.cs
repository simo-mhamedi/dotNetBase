using Project_Spring_to_.net.Business.Contracts;
using Project_Spring_to_.net.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
using Project_Spring_to_.net.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Project_Spring_to_.net.Models.DTO;

namespace Project_Spring_to_.net.Business
{
    public class ClientService : IClientService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ClientService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ClientDto> Getclients()
        {
            if (_context.clients == null)
            {
                throw new ApplicationException("not found");
            }
            return _mapper.Map<IEnumerable<ClientDto>>(_context.clients.ToList());
        }

        public ClientDto GetClient(int id)
        {
            var client = _context.clients.FirstOrDefault(c => c.Id == id);

            if (client == null)
            {
                throw new ApplicationException("not found");
            }

            return _mapper.Map<ClientDto>(client);
        }

        public void PutClient(int id, ClientDto client)
        {
            if (!ClientExists(id))
            {
                throw new ApplicationException("not found");
            }
            Client updatedClient = _mapper.Map<Client>(client);
            _context.Entry(updatedClient).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void PostClient(ClientDto client)
        {
            if (ClientExists(client.Id))
            {
                throw new ApplicationException("Already exist");
            }
            Client savedClient = _mapper.Map<Client>(client);
            _context.clients.Add(savedClient);
            _context.SaveChanges();
        }

        public void DeleteClient(int id)
        {
            if (!ClientExists(id))
            {
                throw new ApplicationException("not found");
            }
            var client = _context.clients.FirstOrDefault(c => c.Id == id);
            Client removedClient = _mapper.Map<Client>(client);

            _context.clients.Remove(removedClient);
            _context.SaveChanges();
        }

        private bool ClientExists(int id)
        {
            return (_context.clients?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }


}
