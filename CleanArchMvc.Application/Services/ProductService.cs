using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services;

public class ProductService : IProductService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ProductService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        var productsQuery = new GetProductsQuery();

        if (productsQuery is null)
            throw new Exception($"Entity could not be loaded");

        var result = await _mediator.Send(productsQuery);

        return _mapper.Map<IEnumerable<ProductDTO>>(result);
    }

    public async Task<ProductDTO> GetById(int id)
    {
        var productByIdQuery = new GetProductByIdQuery(id);

        if (productByIdQuery is null)
            throw new Exception("Ëntity could not be loaded");

        var result = await _mediator.Send(productByIdQuery);

        return _mapper.Map<ProductDTO>(result);
    }

    public async Task<ProductDTO> GetProductCategory(int id)
    {
        var productByIdQuery = new GetProductByIdQuery(id);

        if (productByIdQuery is null)
            throw new Exception("Ëntity could not be loaded");

        var result = await _mediator.Send(productByIdQuery);

        return _mapper.Map<ProductDTO>(result);
    }

    public async Task Add(ProductDTO productDto)
    {
        var produtCreateCommand = _mapper.Map<ProductCreateCommand>(productDto);
        await _mediator.Send(produtCreateCommand);
    }

    public async Task Update(ProductDTO productDto)
    {
        var produtUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDto);
        await _mediator.Send(produtUpdateCommand);
    }

    public async Task Delete(int id)
    {
        var productRemoveCommand = new ProductRemoveCommand(id);

        if (productRemoveCommand is null)
            throw new Exception("Entity could not be loaded");

        await _mediator.Send(productRemoveCommand);
    }

}
