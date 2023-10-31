using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entidades;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Orden, OrdenDto>()
                .ForMember(p => p.Persona, o => o.MapFrom(x => x.Persona.Nombre))
                .ForMember(p => p.Producto, o => o.MapFrom(x => x.Producto.Nombre));
        }
    }
}