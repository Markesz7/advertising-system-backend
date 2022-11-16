using AdvertisingSystem.Dal.Entities;
using AutoMapper;

namespace AdvertisingSystem.Bll.Dtos
{
    public class WebApiProfile : Profile
    {
        public WebApiProfile()
        {
            // This creates a two way map.
            CreateMap<Ad, AdDTO>().ReverseMap();
            CreateMap<Transportline, TransportlineDTO>().ReverseMap();
            // TODO: The advertiser ads should be AdDTO and not Ad entity
            CreateMap<Advertiser, AdvertiserDTO>().ReverseMap();
            CreateMap<Receipt, ReceiptDTO>().ReverseMap();
            CreateMap<TransportCompany, RevenueDTO>();
            CreateMap<Revenue, RevenueDTO>();
            CreateMap<RestrictAdDTO, Ad>();
            CreateMap<ToggleAdvertiserDTO, Advertiser>();
            CreateMap<MoneyDTO, Advertiser>();
            // TODO: This might not need a reversemap
            //CreateMap<Ad, VehicleAdDTO>().ReverseMap();
            CreateMap<Transportline, IEnumerable<VehicleAdDTO>>()
                .ConvertUsing(source => source.Ads.Select(ad => new VehicleAdDTO(ad.Id, 0, ad.AdURL)).ToList());
        }
    }
}
