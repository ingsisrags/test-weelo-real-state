using AutoMapper;
using Product.Domain.Realstate;
using Product.DTOs.Realstate.Input;
using Product.DTOs.Realstate.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Mappers.Realstate
{
    public class PropertyMapper : Profile
    {
        public PropertyMapper()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<CreatePropertyInput, Property>();
            CreateMap<CreateOwnerInput, Owner>();
            CreateMap<CreatePropertyTrace, PropertyTrace>();
            CreateMap<Property, PropertyOutput>();
        }
    }
}
