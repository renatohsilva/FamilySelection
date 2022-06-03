using AutoMapper;
using FamilySelection.Application.Common.Helper;
using FamilySelection.Application.Common.Responses;
using FamilySelection.Domain.DTOs;
using FamilySelection.Domain.Entities;
using FamilySelection.Service.Common.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FamilySelection.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class FamilyController : ControllerBase
    {
        private readonly IFamilyService familyService;
        private readonly IMapper mapper;

        public FamilyController(IFamilyService familyService, IMapper mapper)
        {
            this.familyService = familyService;
            this.mapper = mapper;
        }


        [HttpGet("GetAbleFamilies")]
        public async Task<ActionResult<List<FamilyDto>>> GetFamiliesDtoByPontuation()
        {
            try
            {
                var familysDto = await familyService.LoadFamiliesDtoByPontuation();
                return Ok(familysDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<FamilyDto>>> Get()
        {
            try
            {
                var familys = await familyService.GetAll().ToListAsync();
                var familysDto = mapper.MapList<Family, FamilyDto>(familys);
                return Ok(familysDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }

        [HttpPost]
        public async Task<ActionResult<FamilyDto>> Post([FromBody] FamilyDto familyDto)
        {
            try
            {
                var family = mapper.Map<FamilyDto, Family>(familyDto);
                await familyService.Create(family);
                return CreatedAtAction(nameof(Post), new { id = family.Id }, familyDto);
            }
            catch (ValidationException vex)
            {
                return BadRequest(new ErrorResponse(vex.Errors.ToListValidationFailureString()));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<FamilyDto>> Put(int id, [FromBody] FamilyDto familyDto)
        {
            try
            {
                var familyDatabase = await familyService.GetById(id);
                if (familyDatabase == null)
                    return NotFound();

                var family = mapper.Map(familyDto, familyDatabase);
                await familyService.Update(id, family);
                return CreatedAtAction(nameof(Put), new { id = family.Id }, family);
            }
            catch (ValidationException vex)
            {
                return BadRequest(new ErrorResponse(vex.Errors.ToListValidationFailureString()));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FamilyDto>> GetById(int id)
        {
            try
            {
                var family = await familyService.GetById(id);

                if (family == null)
                    return NotFound();

                var familyDto = mapper.Map<Family, FamilyDto>(family);
                return Ok(familyDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FamilyDto>> Delete(int id)
        {
            try
            {
                var family = await familyService.GetById(id);

                if (family == null)
                    return NotFound();

                await familyService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }

    }
}
