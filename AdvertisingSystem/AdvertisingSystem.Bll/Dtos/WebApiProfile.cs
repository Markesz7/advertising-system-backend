using AdvertisingSystem.Dal.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

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
            //CreateMap<Transportline, IEnumerable<VehicleAdDTO>>()
            //    .ConvertUsing(source => 
            //    source.Ads.Select(ad => new VehicleAdDTO(ad.Id, 0, ad.AdURL)).ToList());

            // TODO: This solution is complex, check if there is a better one
            // The nullable warnings can't ne null, disable it in the future
            CreateMap<Transportline, IEnumerable<VehicleAdDTO>>()
                .ConvertUsing(source => source.Ads.Where(x => !source.AdBans.Select(adban => adban.AdId).Contains(x.Id) 
                || (source.AdBans.Select(adban => adban.AdId).Contains(x.Id) && x.AdBan.SubstituteAdURL != null))
                .Select(ad => new VehicleAdDTO(ad.Id, ad.AdBan == null ? 0 : -1, ad.AdBan == null ? ad.AdURL : ad.AdBan.SubstituteAdURL)));
        }
    }
}
