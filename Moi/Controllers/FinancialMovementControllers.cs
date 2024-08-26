
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
    public class FinancialMovementsController : BaseController
    {
        private readonly IFinancialMovementServices _financialmovementServices;

        public FinancialMovementsController(IFinancialMovementServices financialmovementServices)
        {
            _financialmovementServices = financialmovementServices;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<FinancialMovementDto>>> GetAll([FromQuery] FinancialMovementFilter filter) => Ok(await _financialmovementServices.GetAll(filter) , filter.PageNumber , filter.PageSize);

        
        [HttpPost]
        public async Task<ActionResult<FinancialMovement>> Create([FromBody] FinancialMovementForm financialmovementForm) => Ok(await _financialmovementServices.Create(financialmovementForm));

        
        [HttpPut("{id}")]
        public async Task<ActionResult<FinancialMovement>> Update([FromBody] FinancialMovementUpdate financialmovementUpdate, Guid id) => Ok(await _financialmovementServices.Update(id , financialmovementUpdate));

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<FinancialMovement>> Delete(Guid id) =>  Ok( await _financialmovementServices.Delete(id));
        
    }
}
