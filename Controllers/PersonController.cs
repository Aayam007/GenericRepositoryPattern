using Business.Interfaces;
using Entities.DTO.Request.Person;
using Entities.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogic<PersonDto, Person> _personBusiness;

        public PersonController(ILogic<PersonDto, Person> personBusiness)
        {
            _personBusiness = personBusiness;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonByIdAsync(int id)
        {
            var person = await _personBusiness.GetById(id);
            return Ok(person);
        }

        [HttpGet]
        public async Task<IEnumerable<PersonDto>> GetAllPerson()
        {
           return await _personBusiness.GetAll();
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddPersonAsync([FromBody] PersonDto personDto)
        {
            return Created(string.Empty, await _personBusiness.Add(personDto));
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdatePersonAsync(int id, [FromBody] PersonDto personDTO)
        {
            var updatedPerson = await _personBusiness.Update(id, personDTO);

            return Ok(updatedPerson);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonAsync(int id)
        {
            await _personBusiness.Delete(id);
            return NoContent();
        }

    }
}