using AutoMapper;
using Project_Spring_to_.net.Models;
using Project_Spring_to_.net.Models.DTO;

namespace Project_Spring_to_.net.Business.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Client, ClientDto>();        
            CreateMap<ClientDto, Client>();

            CreateMap<ClientCategory, ClientCategoryDto>();
            CreateMap<ClientCategoryDto, ClientCategory>();


            CreateMap<Purchase, PurchaseDto>();
            CreateMap<PurchaseDto, Purchase>();

        }
    }
}
