using Project_Spring_to_.net.Models.DTO;

namespace Project_Spring_to_.net.Business.Contracts
{
    public interface IPurchaseService
    {
        IEnumerable<PurchaseDto> GetPurchases();
        PurchaseDto GetPurchase(int id);
        void PutPurchase(int id, PurchaseDto purchase);
        void PostPurchase(PurchaseDto purchase);
        void DeletePurchase(int id);
    }
}
