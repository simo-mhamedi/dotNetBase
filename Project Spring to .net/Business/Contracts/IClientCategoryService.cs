using Project_Spring_to_.net.Models.DTO;

namespace Project_Spring_to_.net.Business.Contracts
{
    public interface IClientCategoryService
    {
        IEnumerable<ClientCategoryDto> GetClientCategorys();
        ClientCategoryDto GetClientCategory(int id);
        void PutClientCategory(int id, ClientCategoryDto client);
        void PostClientCategory(ClientCategoryDto client);
        void DeleteClientCategory(int id);

    }
}
