using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers;

[Authorize]
public class CategoriesController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var categories = await _categoryService.GetCategories();
        return View(categories);
    }

    [HttpGet()]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryDTO categoryDTO)
    {
        if (ModelState.IsValid)
        {
            await _categoryService.Add(categoryDTO);
            return RedirectToAction(nameof(Index));
        }

        return View(categoryDTO);
    }

    [HttpGet()]
    public async Task<IActionResult> Edit(int id)
    {
        var categoryDto = await _categoryService.GetById(id);

        if (categoryDto is null) return NotFound();

        return View(categoryDto);
    }

    [HttpPost()]
    public async Task<IActionResult> Edit(CategoryDTO categoyDto)
    {
        if (ModelState.IsValid) 
        {
            try
            {
                await _categoryService.Update(categoyDto);
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(categoyDto);
    }

    [HttpGet()]
    public async Task<IActionResult> Delete(int id) 
    {
        var categoryDto = await _categoryService.GetById(id);

        if (categoryDto is null) return NotFound();

        return View(categoryDto);
    }

    [HttpPost(), ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _categoryService.Delete(id);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Details(int id)
    {
        var categoryDto = await _categoryService.GetById(id);

        if (categoryDto is null) return NotFound();

        return View(categoryDto);
    }
}
