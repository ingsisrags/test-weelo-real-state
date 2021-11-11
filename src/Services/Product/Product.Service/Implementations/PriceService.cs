using AutoMapper;
using Common.Utilities.Exceptions;
using Common.Utilities.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Product.Domain.Realstate;
using Product.DTOs.Realstate.Input;
using Product.DTOs.Realstate.Output;
using Product.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Service.Implementations
{
    public class PriceService : IPriceService
    {

        private readonly IRepositoryAsync<Property> _propertyRepository;
        private readonly IMapper _mapper;
        public PriceService(IRepositoryAsync<Property> propertyRepository, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }
        public async Task<PropertyOutput> ChangePrice(UpdatePriceInput input)
        {
            var property = await _propertyRepository.GetAll().FirstOrDefaultAsync(x => x.Id == input.PropertyId);
            if (property is null)
            {
                throw new NotFoundException("Product don't find");
            }

            property = _mapper.Map(input, property);

            property = await _propertyRepository.UpdateAsync(property);

            await _propertyRepository.Commit();

            return _mapper.Map<PropertyOutput>(property);

        }
    }
}
