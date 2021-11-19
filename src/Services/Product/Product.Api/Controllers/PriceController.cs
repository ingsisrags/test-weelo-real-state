using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.DTOs.Realstate.Input;
using Product.DTOs.Realstate.Output;
using Product.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Api.Controllers
{
    [Route("price")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IImageService _imageService;
        private readonly IPriceService _priceService;
        public PriceController(IProductService productService, IImageService imageService, IPriceService priceService)
        {
            _productService = productService;
            _imageService = imageService;
            _priceService = priceService;

        }

        /// <summary>
        /// Method for change price to property
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        [HttpPut("v1/change-price-property")]
        public async Task<PropertyOutput> ChangePrice([FromBody] UpdatePriceInput input)
        {
            return await _priceService.ChangePrice(input);
        }

        [HttpGet("v1/get-price-range")]
        public async Task<RangePriceOutput> GetRangePrice()
        {
            return await _priceService.GetPriceRange();
        }
    }
}
