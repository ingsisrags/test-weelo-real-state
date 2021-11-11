using AutoMapper;
using Common.Utilities.Directory;
using Common.Utilities.Exceptions;
using Common.Utilities.Interfaces.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Product.Domain.Realstate;
using Product.DTOs.Realstate.Input;
using Product.DTOs.Realstate.Output;
using Product.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Service.Implementations
{
    public class ImageService : IImageService
    {

        private readonly IRepositoryAsync<PropertyImage> _propertyImageRepository;
        private readonly IRepositoryAsync<Property> _propertyRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IUnitOfWork _unitOfWork;

        public ImageService(IRepositoryAsync<PropertyImage> propertyImageRepository, IRepositoryAsync<Property> propertyRepository, IMapper mapper, IWebHostEnvironment hostEnvironment, IUnitOfWork unitOfWork)
        {
            _propertyRepository = propertyRepository;
            _propertyImageRepository = propertyImageRepository;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
            _unitOfWork = unitOfWork;

        }
        public async Task<ImageOutput> CreateImages(CreateImagePropertyInput input)
        {
            var property = await _propertyRepository.GetAll().FirstOrDefaultAsync(x => x.Id == input.PropertyId);
            if (property is null)
            {
                throw new NotFoundException("Product don't find");
            }
            var file = await UploadedFile(input.Image);
            var propertyImage = _mapper.Map(file, _mapper.Map<PropertyImage>(property));
            propertyImage = await _propertyImageRepository.InsertAsync(propertyImage);
            await _propertyImageRepository.Commit();
            return _mapper.Map<ImageOutput>(propertyImage);

        }

        public async Task<PropertyOutput> UpdateView(List<UpdateViewsOrder> input, Guid PropertyId)
        {
            var property = await _propertyRepository.GetAll().AnyAsync(x => x.Id == PropertyId);
            if (!property)
            {
                throw new NotFoundException("Product don't find");
            }

            foreach (var i in input)
            {
                var image = await _propertyImageRepository.GetAll().FirstOrDefaultAsync(x => x.Id == i.ImageId && x.PropertyId==PropertyId); 
                if (image != null)
                {
                    image.Order = i.Order;
                    _propertyImageRepository.Update(image);
                }
            }

            _unitOfWork.SaveChanges();

            var propertyReturn = await _propertyRepository.GetAll().Include(x=>x.PropertyImage).FirstOrDefaultAsync(x => x.Id == PropertyId);
            return _mapper.Map<PropertyOutput>(propertyReturn);
        }

        private async Task<string> UploadedFile(IFormFile image)
        {
            string fileName = Path.GetFileNameWithoutExtension(image.FileName);
            string extension = Path.GetExtension(image.FileName);
            fileName = $"{Guid.NewGuid()}-{fileName}{extension}";
            string path = Path.Combine("Images/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            return fileName;
        }
    }
}
