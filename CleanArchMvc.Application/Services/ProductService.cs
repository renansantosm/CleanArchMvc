using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
       var productsEntity = await _repository.GetProductsAsync();
        return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
    }

    public async Task<ProductDTO> GetById(int id)
    {
        var productEntity = await _repository.GetByIdAsync(id);
        return _mapper.Map<ProductDTO>(productEntity);
    }

    public Task<ProductDTO> GetProductCategory(int id)
    {
        throw new NotImplementedException();
    }

    public Task Add(ProductDTO productDto)
    {
        throw new NotImplementedException();
    }

    public Task Update(ProductDTO productDto)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

}
