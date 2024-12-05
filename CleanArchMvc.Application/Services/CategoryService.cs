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

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<IEnumerable<CategoryDTO>> GetCategories()
    {
        throw new NotImplementedException();
    }

    public Task<ProductDTO> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Add(CategoryDTO categoryDto)
    {
        throw new NotImplementedException();
    }

    public Task Update(CategoryDTO categoryDto)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

}
