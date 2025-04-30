using BaseModel.Application.DTOs;
using BaseModel.Application.Interfaces;
using BaseModel.Application.Shareds;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaseModel.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController
        (
            ICategoryService categoryService
        )
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAll()
        {
            var categories = await _categoryService.GetAll();
            if (categories == null)
            {
                return NotFound("Categories not Founds");
            }
            return Ok(categories);
        }
        [HttpGet("{Id:Guid}", Name = "GetCategoryById")]
        public async Task<ActionResult<CategoryDTO>> GetById(Guid Id)
        {
            var category = await _categoryService.GetById(Id);
            if (category == null) return NotFound("Category not Found");
            return Ok(category);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO == null) return BadRequest("Invalid Data");
            var result = await _categoryService.Add(categoryDTO);
            if (!result.ValidationResult.IsValid)
            {
                var firstError = result.ValidationResult.Errors.FirstOrDefault()?.ErrorMessage ?? "Erro inesperado.";
                return BadRequest(new ErrorResponse(firstError));
            }

            return Ok(result.Data);
        }
        [HttpPut("{Id:Guid}")]
        public async Task<ActionResult> Update([FromBody] CategoryDTO categoryDTO, Guid Id)
        {
            if (categoryDTO == null) return BadRequest("Invalid Data");
            categoryDTO.Id = Id;
            var result = await _categoryService.Update(categoryDTO);
            if (!result.IsValid)
            {
                var firstError = result.Errors.FirstOrDefault()?.ErrorMessage ?? "Erro inesperado.";
                return BadRequest(new ErrorResponse(firstError));
            }

            return Ok();
        }

        [HttpDelete("{Id:Guid}")]
        public async Task<ActionResult> Delete(Guid Id)
        {
            var result = await _categoryService.Remove(Id);
            if (!result.IsValid)
            {
                var firstError = result.Errors.FirstOrDefault()?.ErrorMessage ?? "Erro inesperado.";
                return BadRequest(new ErrorResponse(firstError));
            }

            return Ok();
        }
    }
}