using AutoMapper;
using Common.Utilities.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Product.Domain.Realstate;
using Product.DTOs.Realstate.Input;
using Product.DTOs.Realstate.Output;
using Product.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Service.Implementations
{
    public class ProductService : IProductService
    {

        private readonly IRepositoryAsync<Property> _propertyRepository;
        private readonly IRepositoryAsync<Owner> _ownerRepository;
        private readonly IRepositoryAsync<PropertyTrace> _propertyTrace;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IRepositoryAsync<Property> propertyRepository, IMapper mapper, IRepositoryAsync<Owner> ownerRepository, IRepositoryAsync<PropertyTrace> propertyTrace, IUnitOfWork unitOfWork)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
            _ownerRepository = ownerRepository;
            _propertyTrace = propertyTrace;
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Method for create the building
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PropertyOutput> CreatePropertyBuilding(CreatePropertyInput input)
        {
            var property = _mapper.Map<Property>(input);
            var propertyTrace = _mapper.Map<PropertyTrace>(input.PropertyTrace);
            await _ownerRepository.InsertAsync(property.Owner);
            property = await _propertyRepository.InsertAsync(property);
            await _propertyTrace.InsertAsync(propertyTrace);
            _unitOfWork.SaveChanges();
            var output = _mapper.Map<PropertyOutput>(property);
            return output;
        }
    }

}
