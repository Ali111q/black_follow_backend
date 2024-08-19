
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
    public class ServicesController : BaseController
    {
        private readonly IServiceServices _serviceServices;

        public ServicesController(IServiceServices serviceServices)
        {
            _serviceServices = serviceServices;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<ServiceDto>>> GetAll([FromQuery] ServiceFilter filter) => Ok(await _serviceServices.GetAll(filter) , filter.PageNumber , filter.PageSize);

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Service>> Create([FromBody] ServiceForm serviceForm) => Ok(await _serviceServices.Create(serviceForm));

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Service>> Update([FromBody] ServiceUpdate serviceUpdate, Guid id) => Ok(await _serviceServices.Update(id , serviceUpdate));

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Service>> Delete(Guid id) =>  Ok( await _serviceServices.Delete(id));
        
    }
}
