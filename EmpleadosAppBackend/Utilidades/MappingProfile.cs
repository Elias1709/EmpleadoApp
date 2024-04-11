using AutoMapper;
using Models.DTOs;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Cargo, CargoDto>()
                .ForMember(d => d.Estado, m => m.MapFrom(o => o.Estado == true ? 1 : 0));

            CreateMap<Empleado, EmpleadoDto>()
                .ForMember(d => d.Estado, m => m.MapFrom(o => o.Estado == true ? 1 : 0))
                .ForMember(d => d.NombreCargo, m => m.MapFrom(o => o.Cargo.Nombre));
        }
    }
}
