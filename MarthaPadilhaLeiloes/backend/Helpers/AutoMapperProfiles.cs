using System.Linq;
using AutoMapper;
using backend.DTOs;
using domain;

namespace backend.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // ForMember e MapFrom sao usados para definir o relacionamento muitos para muitos
            CreateMap<Auction, AuctionDTO>()
                .ForMember(destinatario => destinatario.Items, option => {
                    option.MapFrom(source => source.AuctionItems.Select(i => i.Item).ToList());
                })
                .ReverseMap();
            CreateMap<Item, ItemDTO>()
                .ForMember(destinatario => destinatario.Auctions, option => {
                    option.MapFrom(source => source.AuctionItems.Select(i => i.Auction).ToList());
                })
                .ReverseMap();
            CreateMap<Comitente, ComitenteDTO>().ReverseMap();
            CreateMap<Negotiation, NegotiationDTO>().ReverseMap();
            CreateMap<TipoItem, TipoItemDTO>().ReverseMap();
        }
    }
}