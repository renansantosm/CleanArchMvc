using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
    {
        var productsDto = await _productService.GetProducts();

        if (productsDto == null)
        {
            return NotFound("Products not found");
        }

        return Ok(productsDto);
    }

    [HttpGet("{id:int}", Name = "GetProduct")]
    public async Task<ActionResult<ProductDTO>> Get(int id)
    {
        var product = await _productService.GetById(id);

        if(product == null)
        {
            return NotFound("Product not found");
        }

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDTO>> Post(ProductDTO productDto)
    {
        if (productDto == null)
        {
            return BadRequest();
        }

        await _productService.Add(productDto);

        return new CreatedAtRouteResult("GetProduct", new { id = productDto.Id }, productDto);
    }

    [HttpPut]
    public async Task<ActionResult<ProductDTO>> Put(int id, ProductDTO productDTO)
    {
        if(productDTO == null)
        {
            return BadRequest();
        }

        if(productDTO.Id != id)
        {
            return BadRequest();
        }

        await _productService.Update(productDTO);

        return Ok(productDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ProductDTO>> Delete(int id)
    {
        var productDto = await _productService.GetById(id);

        if(productDto == null)
        {
            return NotFound("Product not found");
        }

        await _productService.Delete(id);

        return Ok(productDto);
    }
}
