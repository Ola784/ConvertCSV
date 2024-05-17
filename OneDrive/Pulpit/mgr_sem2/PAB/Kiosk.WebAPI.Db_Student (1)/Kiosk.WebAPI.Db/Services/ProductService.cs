using Kiosk.WebAPI.Dto;
using Kiosk.WebAPI.Models;
using Kiosk.WebAPI.Persistance;
using Microsoft.EntityFrameworkCore;
using Kiosk.WebAPI.Db.Exceptions;


namespace Kiosk.WebAPI.Db.Services
{

    public class ProductService : IProductService
    {
        private readonly IKioskUnitOfWork _uow;

        public ProductService(IKioskUnitOfWork unitOfWork)
        {
            this._uow = unitOfWork;
        }

        public int Create(CreateProductDto dto)
        {
            if (dto == null)
            {
                throw new NotFoundException("Product is null");
            }

            var id = _uow.ProductRepository.GetMaxId() + 1;
            var product = new Product()
            {
                Id = id,
                Name = dto.Name,
                Description = dto.Description,
                UnitPrice = dto.UnitPrice,
                CreatedAt = DateTime.Now,
            };
            _uow.ProductRepository.Insert(product);
            _uow.Commit();


            return id;
        }

        public void Delete(int id)
        {
            var product = _uow.ProductRepository.Get(id);
            if (product == null)
            {
                throw new NotFoundException("Product not found");
            }

            _uow.ProductRepository.Delete(product);
            _uow.Commit();
        }

        public List<ProductDto> GetAll()
        {
            var products = _uow.ProductRepository.GetAll();

            List<ProductDto> result = new List<ProductDto>();
            foreach (var s in products)
            {
                result.Add(new ProductDto()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    UnitPrice = s.UnitPrice,
                });
            }

            return result;
        }

        public ProductDto GetById(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id is less than zero");
            }

            var product = _uow.ProductRepository.Get(id);
            if (product == null)
            {
                throw new NotFoundException("Product not found");
            }

            var result = new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                UnitPrice = product.UnitPrice,
            };

            return result;
        }

        public void Update(UpdateProductDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("No product data");
            }

            var product = _uow.ProductRepository.Get(dto.Id);
            if (product == null)
            {
                throw new NotFoundException("Product not found");
            }

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.UnitPrice = dto.UnitPrice;

            _uow.Commit();
        }
    }
}
