using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Product.DTOs.Realstate.Input;
using Product.DTOs.Realstate.Output;
using Product.Service.Interfaces;

namespace Product.Api.Controllers
{
    [Route("property")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IImageService _imageService;
        private readonly IPriceService _priceService;
        public PropertyController(IProductService productService, IImageService imageService, IPriceService priceService)
        {
            _productService = productService;
            _imageService = imageService;
            _priceService = priceService;

        }
        /// <summary>
        /// Get Product by Filters
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("v1/get-properties")]
        public async Task<List<PropertyOutput>> GetProperties([FromQuery] FilterPropertyInput input)
        {
            return await _productService.GetProperties(input);
        }

        /// <summary>
        /// Method find product by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        [HttpGet("v1/get-property-by-id/{Id}")]
        public async Task<PropertyOutput> GetPropertiesById([FromRoute] Guid Id)
        {
            return await _productService.GetPropertiesById(Id);
        }

        /// <summary>
        /// Post method for create building, return object with Id and name
        /// </summary>
        /// <returns></returns>
        [HttpPost("v1/create-property")]
        public async Task<PropertyOutput> CreateBuilding(CreatePropertyInput input)
        {
            var output = await _productService.CreatePropertyBuilding(input);
            return output;
        }

        /// <summary>
        /// Method for create image of property
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        [HttpPost("v1/create-image-property")]
        public async Task<ImageOutput> CreateImages([FromForm] CreateImagePropertyInput input)
        {
            return await _imageService.CreateImages(input);
        }
     
        /// <summary>
        /// Method for update image order view
        /// </summary>
        /// <param name="input"></param>
        /// <param name="PropertyId"></param>
        /// <returns></returns>

        [HttpPut("v1/update-view-property")]
        public async Task<PropertyOutput> UpdateView([FromBody]  List<UpdateViewsOrder> input, [FromQuery] Guid PropertyId)
        {
            return await _imageService.UpdateView(input, PropertyId);
        }

    }
}
