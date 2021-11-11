using Product.DTOs.Realstate.Input;
using Product.DTOs.Realstate.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Service.Interfaces
{
    public interface IImageService
    {
        Task<ImageOutput> CreateImages(CreateImagePropertyInput input);
    }
}
