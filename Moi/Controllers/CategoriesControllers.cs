
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
    public class CategoriessController : BaseController
    {
        private readonly ICategoriesServices _categoriesServices;

        public CategoriessController(ICategoriesServices categoriesServices)
        {
            _categoriesServices = categoriesServices;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<CategoriesDto>>> GetAll([FromQuery] CategoriesFilter filter) => Ok(await _categoriesServices.GetAll(filter) , filter.PageNumber , filter.PageSize);

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Categories>> Create([FromBody] CategoriesForm categoriesForm) => Ok(await _categoriesServices.Create(categoriesForm));

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Categories>> Update([FromBody] CategoriesUpdate categoriesUpdate, Guid id) => Ok(await _categoriesServices.Update(id , categoriesUpdate));

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Categories>> Delete(Guid id) =>  Ok( await _categoriesServices.Delete(id));
        
    }
}
