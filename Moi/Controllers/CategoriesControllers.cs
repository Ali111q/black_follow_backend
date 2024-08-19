using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.Entities;
using BackEndStructuer.Services;
using GaragesStructure.Controllers;
using GaragesStructure.Respository.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndStructuer.Controllers
{
    public class CategoriesController : BaseController
    {
        private readonly ICategoriesServices _categoriesServices;

        public CategoriesController(ICategoriesServices categoriesServices)
        {
            _categoriesServices = categoriesServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoriesDto>>> GetAll([FromQuery] CategoriesFilter filter)
        {
            var (categories, totalCount, error) = await _categoriesServices.GetAll(filter);
            if (error != null)
                return BadRequest(error);

            Response.Headers.Add("X-Total-Count", totalCount?.ToString());
            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult<Categories>> Create([FromBody] CategoriesForm categoriesForm)
        {
            var (category, error) = await _categoriesServices.Create(categoriesForm);
            if (error != null)
                return BadRequest(error);

            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Categories>> Update([FromBody] CategoriesUpdate categoriesUpdate, Guid id)
        {
            var (category, error) = await _categoriesServices.Update(id, categoriesUpdate);
            if (error != null)
                return BadRequest(error);

            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Categories>> Delete(Guid id)
        {
            var (category, error) = await _categoriesServices.Delete(id);
            if (error != null)
                return BadRequest(error);

            return Ok(category);
        }
    }
}
