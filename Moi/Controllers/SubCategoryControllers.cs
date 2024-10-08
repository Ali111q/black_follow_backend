
using BackEndStructuer.DATA.DTOs;

using BackEndStructuer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.Entities;
using System.Threading.Tasks;
using GaragesStructure.Controllers;

namespace BackEndStructuer.Controllers
{
    public class SubCategorysController : BaseController
    {
        private readonly ISubCategoryServices _subcategoryServices;

        public SubCategorysController(ISubCategoryServices subcategoryServices)
        {
            _subcategoryServices = subcategoryServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<SubCategoryDto>>> GetAll([FromQuery] SubCategoryFilter filter) => Ok(await _subcategoryServices.GetAll(filter) , filter.PageNumber , filter.PageSize);

        [HttpPost]
        public async Task<ActionResult<SubCategory>> Create([FromBody] SubCategoryForm subcategoryForm) => Ok(await _subcategoryServices.Create(subcategoryForm));

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<SubCategory>> Update([FromBody] SubCategoryUpdate subcategoryUpdate, Guid id) => Ok(await _subcategoryServices.Update(id , subcategoryUpdate));

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<SubCategory>> Delete(Guid id) =>  Ok( await _subcategoryServices.Delete(id));
        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategory>> GetById(Guid id)
        {
            var (subcategory, error) = await _subcategoryServices.GetById(id);
            if (error != null)
                return NotFound(error);
            
            return Ok(subcategory);
        }
    }
}
