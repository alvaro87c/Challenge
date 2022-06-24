using API.DTO;
using AutoMapper;
using CORE.Entidades;

namespace API.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Cliente, ClienteDTO>()
            .ReverseMap();
        CreateMap<Cliente, ClienteAddUpdateDTO>()
            .ReverseMap();
    }

}
