using AdvertisingSystem.Dal.Entities;
using AutoMapper;
using Microsoft.Data.SqlClient;

namespace AdvertisingSystem.Bll.Dtos
{
    public class WebApiProfile : Profile
    {
        public WebApiProfile()
        {
            // This creates a two way map.
            CreateMap<Ad, AdResponseDTO>();
            CreateMap<AdRequestDTO, Ad>();
            CreateMap<Transportline, TransportlineDTO>().ReverseMap();
            CreateMap<Advertiser, AdvertiserDTO>().ReverseMap();
            CreateMap<Advertiser, ApplicationUserDTO>();
            CreateMap<AdOrganiser, ApplicationUserDTO>();
            CreateMap<TransportCompany, ApplicationUserDTO>();
            CreateMap<Receipt, ReceiptDTO>().ReverseMap();
            CreateMap<TransportCompany, RevenueDTO>();
            CreateMap<Revenue, RevenueDTO>();
            CreateMap<AdBan, AdBanDTO>().ReverseMap();
            CreateMap<ToggleAdvertiserDTO, Advertiser>();
            CreateMap<MoneyDTO, Advertiser>();
            // TODO: This solution is complex, check if there is a better one
            // The nullable warnings can't ne null, disable it in the future
            CreateMap<Ad, VehicleAdDTO>();
            CreateMap<AdTransportline, VehicleAdDTO>()
                .ConvertUsing(source => new VehicleAdDTO(
                    source.Ad.Id, 
                    source.AdBan == null ? 0 : -1, 
                    source.AdBan == null ? 
                        source.Ad.AdURL.Remove(4, 10).Insert(4, "vehicle") : 
                        source.AdBan.SubstituteAdURL.Remove(4, 10).Insert(4, "vehicle")));

            
        }
    }
}
