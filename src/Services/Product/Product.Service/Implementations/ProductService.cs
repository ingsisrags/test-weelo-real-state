using AutoMapper;
using Common.Utilities.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Product.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Service.Implementations
{
    public class ProductService : IProductService
    {

        //private readonly IRepositoryAsync<Strain> _strainRepository;
        //private readonly IMapper _mapper;

        //public ProductService(IRepositoryAsync<Strain> strainRepository, IMapper mapper)
        //{
        //    _strainRepository = strainRepository;
        //    _mapper = mapper;
        //}
        //public async Task<List<StrainOutput>> GetAll()
        //{
        //    return _mapper.Map<List<StrainOutput>>(await _strainRepository.GetAll().ToListAsync());

        //}
    }

}
