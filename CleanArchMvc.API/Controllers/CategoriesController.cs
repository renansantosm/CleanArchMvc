using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
    {
        var categoriesDto = await _categoryService.GetCategories();

        if (categoriesDto == null)
        {
            return NotFound();
        }

        return Ok(categoriesDto);
    }

    [HttpGet("{id:int}", Name = "GetCategory")]
    public async Task<ActionResult<CategoryDTO>> Get(int id)
    {
        var categoryDto = await _categoryService.GetById(id);

        if(categoryDto == null)
        {
            return NotFound("Category Not Found");
        }

        return Ok(categoryDto);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDTO>> Create(CategoryDTO categoryDTO)
    {
        if(categoryDTO == null)
        {
            return BadRequest();
        }

        await _categoryService.Add(categoryDTO);

        return new CreatedAtRouteResult("GetCategory", new { id = categoryDTO.Id}, categoryDTO);
    }

    [HttpPut]
    public async Task<ActionResult<CategoryDTO>> Put(int id, CategoryDTO categoryDto)
    {
        if(categoryDto == null)
        {
            return BadRequest();
        }

        if(categoryDto.Id != id)
        {
            return BadRequest();
        }

        await _categoryService.Update(categoryDto);

        return Ok(categoryDto);
    }

    [HttpDelete]
    public async Task<ActionResult<CategoryDTO>> Delete(int id)
    {
        var categoryDto = await _categoryService.GetById(id);

        if(categoryDto is null)
        {
            return NotFound("Category not found");
        }

        await _categoryService.Delete(id);

        return Ok(categoryDto);
    }
}
