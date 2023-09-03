using Project_Spring_to_.net.Models.DTO;

namespace Project_Spring_to_.net.Business.Contracts
{
    public interface IClientService
    {
        IEnumerable<ClientDto> Getclients();
        ClientDto GetClient(int id);
        void PutClient(int id, ClientDto client);
        void PostClient(ClientDto client);
        void DeleteClient(int id);
    }
}
