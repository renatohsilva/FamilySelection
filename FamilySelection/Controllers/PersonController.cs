using AutoMapper;
using FamilySelection.Application.Common.Helper;
using FamilySelection.Application.Common.Responses;
using FamilySelection.Domain.DTOs;
using FamilySelection.Domain.Entities;
using FamilySelection.Service.Common.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PersonSelection.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService personService;
        private readonly IMapper mapper;

        public PersonController(IPersonService personService, IMapper mapper)
        {
            this.personService = personService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonDto>>> Get()
        {
            try
            {
                var persons = await personService.GetAll().ToListAsync();
                var personsDto = mapper.MapList<Person, PersonDto>(persons);
                return Ok(personsDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }

        [HttpPost]
        public async Task<ActionResult<PersonDto>> Post([FromBody] PersonDto personDto)
        {
            try
            {
                var person = mapper.Map<PersonDto, Person>(personDto);
                await personService.Create(person);
                return CreatedAtAction(nameof(Post), new { id = person.Id }, personDto);
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
        public async Task<ActionResult<PersonDto>> Put(int id, [FromBody] PersonDto personDto)
        {
            try
            {
                var personDatabase = await personService.GetById(id);
                if (personDatabase == null)
                    return NotFound();

                var person = mapper.Map(personDto, personDatabase);
                await personService.Update(id, person);
                return CreatedAtAction(nameof(Put), new { id = person.Id }, person);
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
        public async Task<ActionResult<PersonDto>> GetById(int id)
        {
            try
            {
                var person = await personService.GetById(id);

                if (person == null)
                    return NotFound();

                var personDto = mapper.Map<Person, PersonDto>(person);
                return Ok(personDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonDto>> Delete(int id)
        {
            try
            {
                var person = await personService.GetById(id);

                if (person == null)
                    return NotFound();

                await personService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }
    }
}
