
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.Helpers;
using BackEndStructuer.Properties;
using BackEndStructuer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.Entities;
using System.Threading.Tasks;

namespace BackEndStructuer.Controllers
{
    public class SubCategorysController : BaseController
    {
        private readonly ISubCategoryServices _subcategoryServices;

        public SubCategorysController(ISubCategoryServices subcategoryServices)
        {
            _subcategoryServices = subcategoryServices;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<SubCategoryDto>>> GetAll([FromQuery] SubCategoryFilter filter) => Ok(await _subcategoryServices.GetAll(filter) , filter.PageNumber , filter.PageSize);

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<SubCategory>> Create([FromBody] SubCategoryForm subcategoryForm) => Ok(await _subcategoryServices.Create(subcategoryForm));

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<SubCategory>> Update([FromBody] SubCategoryUpdate subcategoryUpdate, Guid id) => Ok(await _subcategoryServices.Update(id , subcategoryUpdate));

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<SubCategory>> Delete(Guid id) =>  Ok( await _subcategoryServices.Delete(id));
        
    }
}
