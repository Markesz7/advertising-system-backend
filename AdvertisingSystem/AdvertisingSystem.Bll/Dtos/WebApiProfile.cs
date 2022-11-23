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
            CreateMap<Advertiser, AdvertiserDTO>().ReverseMap();
            //CreateMap<AdvertiserRegisterDTO, Advertiser>();
            CreateMap<Receipt, ReceiptDTO>().ReverseMap();
            CreateMap<TransportCompany, RevenueDTO>();
            CreateMap<Revenue, RevenueDTO>();
            CreateMap<AdBan, AdBanDTO>().ReverseMap();
            CreateMap<ToggleAdvertiserDTO, Advertiser>();
            CreateMap<MoneyDTO, Advertiser>();
            // TODO: This might not need a reversemap
            //CreateMap<Ad, VehicleAdDTO>().ReverseMap();
            //CreateMap<Transportline, IEnumerable<VehicleAdDTO>>()
            //    .ConvertUsing(source => 
            //    source.Ads.Select(ad => new VehicleAdDTO(ad.Id, 0, ad.AdURL)).ToList());

            /*
            CreateMap<Transportline, IEnumerable<VehicleAdDTO>>()
                .ConvertUsing(source => source.Ads.Where(x => !source.AdBans.Select(adban => adban.AdId).Contains(x.Id) 
                || (source.AdBans.Select(adban => adban.AdId).Contains(x.Id) && x.AdBan.SubstituteAdURL != null))
                .Select(ad => new VehicleAdDTO(ad.Id, ad.AdBan == null ? 0 : -1, ad.AdBan == null ? ad.AdURL : ad.AdBan.SubstituteAdURL)));
            */
            // TODO: This solution is complex, check if there is a better one
            // The nullable warnings can't ne null, disable it in the future
            CreateMap<Ad, VehicleAdDTO>();
            CreateMap<AdTransportline, VehicleAdDTO>()
                .ConvertUsing(source => new VehicleAdDTO(
                    source.Ad.Id, 
                    source.AdBan == null ? 0 : -1, 
                    source.AdBan == null ? source.Ad.AdURL : source.AdBan.SubstituteAdURL));

            
        }
    }
}
