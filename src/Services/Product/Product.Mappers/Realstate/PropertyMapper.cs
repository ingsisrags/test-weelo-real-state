using AutoMapper;
using Common.Utilities.FileUtilities;
using Product.Domain.Realstate;
using Product.DTOs.Realstate.Input;
using Product.DTOs.Realstate.Output;
using System;
using System.Collections.Generic;
using System.IO;
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
            CreateMap<PropertyTrace, PropertyTraceOutput>();
            CreateMap<CreatePropertyTrace, PropertyTrace>();
            CreateMap<UpdatePriceInput, Property>();
            CreateMap<PropertyImage, ImageOutput>()
                .ForMember(x => x.Base64, pro => pro.MapFrom(y => FileUtilities.GetBase64FromPath(y.File)));
            CreateMap<Owner, OwnerOutput>();
            CreateMap<Property, PropertyImage>()
                  .ForMember(x => x.PropertyId, pro => pro.MapFrom(y => y.Id))
                  .ForMember(x => x.Id, pro => pro.Ignore())
                ;
            CreateMap<string, PropertyImage>()
                 .ForMember(x => x.File, pro => pro.MapFrom(y => Path.Combine("Images/", y)))
                 .ForMember(x => x.Enabled, pro => pro.MapFrom(y => true));
            ;
            
            CreateMap<Property, PropertyTrace>()
                .ForMember(x => x.PropertyId, pro => pro.MapFrom(y => y.Id))
                .ForMember(x => x.Name, pro => pro.Ignore());
            CreateMap<PropertyImage, PropertyViewOrderOutput>().ForMember(x => x.ImageId, pro => pro.MapFrom(y => y.Id));

        }
    }
}
