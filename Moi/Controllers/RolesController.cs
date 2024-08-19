using GaragesStructure.DATA.DTOs.roles;
using GaragesStructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GaragesStructure.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : BaseController
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: api/roles
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var (roles, totalCount, error) = await _roleService.GetAll();
            if (error != null)
                return BadRequest(error);

            Response.Headers.Add("X-Total-Count", totalCount?.ToString());
            return Ok(roles);
        }

        // POST: api/roles
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] RoleForm roleForm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var (role, error) = await _roleService.Add(roleForm);
            if (error != null)
                return BadRequest(error);

            return CreatedAtAction(nameof(GetAll), new { id = role.Id }, role);
        }

        // PUT: api/roles/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, [FromBody] RoleForm roleForm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var (roleDto, error) = await _roleService.Edit(id, roleForm);
            if (error != null)
                return BadRequest(error);

            return Ok(roleDto);
        }

        // DELETE: api/roles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var (roleDto, error) = await _roleService.Delete(id);
            if (error != null)
                return BadRequest(error);

            return Ok(roleDto);
        }

        // GET: api/roles/{id}/permissions
        [HttpGet("{id}/permissions")]
        public async Task<IActionResult> GetPermissions(Guid id)
        {
            var (permissions, error) = await _roleService.GetAllPermissions(new PermissionsFilter { RoleId = id });
            if (error != null)
                return BadRequest(error);

            return Ok(permissions);
        }

        // POST: api/roles/permissions
        [HttpPost("permissions")]
        public async Task<IActionResult> AssignPermissions([FromBody] AssignPermissionsDto assignPermissions)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var (result, error) = await _roleService.AddPermissionToRole(assignPermissions.Id, assignPermissions);
            if (error != null)
                return BadRequest(error);

            return Ok(result);
        }

    }
}
