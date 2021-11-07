using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Product.Api.Controllers
{
    [Route("RealState")]
    [ApiController]
    public class CultivateController : ControllerBase
    {
        //private readonly ICultivateService _cultivateService ;
        //public CultivateController(ICultivateService cultivateService)
        //{
        //    _cultivateService = cultivateService;
        //}

        //[HttpGet]
        //[Authorize]
        //public async Task<List<CultivateOutput>> GetAll()
        //{
        //    var output = await _cultivateService.GetAll();
        //    return output;
        //}

        //[HttpPost]
        //[Authorize]
        //public async Task<CultivateOutput> Create([FromBody] CreateCultivateInput input)
        //{
        //    var output = await _cultivateService.Create(input);
        //    return output;
        //}

        //[HttpPut]
        //[Authorize]
        //public async Task<CultivateOutput> Update([FromBody] UpdateCultivateInput input)
        //{
        //    var output = await _cultivateService.Update(input);
        //    return output;
        //}

        //[Authorize]
        //[HttpGet("grow-cultivate-by-id")]
        //public async Task<CultivateOutput> GetById([FromQuery] [Required] Guid id)
        //{
        //    var output = await _cultivateService.GetBiId(id);
        //    return output;
        //}

    }
}
