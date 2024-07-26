namespace DestinyBuildsBack.Mappings;
using AutoMapper;
using DestinyBuildsBack.DTOs;
using DestinyBuildsBack.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Build, BuildDto>().ReverseMap();
        CreateMap<Clase, ClaseDto>().ReverseMap();
        CreateMap<Subclase, SubclaseDto>().ReverseMap();
        CreateMap<Arma, ArmaDto>().ReverseMap();
        CreateMap<ArmaduraExotica, ArmaduraExoticaDto>().ReverseMap();
    }
}