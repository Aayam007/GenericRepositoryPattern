using AutoMapper;
using Business.Interfaces;
using Entities.DTO.Request.Person;
using Entities.Entity;
using Microsoft.Extensions.Logging;
using Persistence.Interfaces;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using System.Threading.Tasks;


namespace Business.Logic
{
    public class PersonLogic : ILogic<PersonDto, Person>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<PersonLogic> _logger;
        private readonly IPersonRepository _personRepository;

        public PersonLogic(IMapper mapper, ILogger<PersonLogic> logger, IPersonRepository personRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _personRepository = personRepository;
        }

        public async Task<Person> Add(PersonDto personDto)
        {
             var Person = _mapper.Map<Person>(personDto);
            var person = await _personRepository.InsertAsync(Person);

            _logger.LogInformation("Added person {person}", person);

            return person;
        }

        public async Task Delete(int id)
        {
            var person = await _personRepository.FindByIdAsync(id);

          //  ArgumentNullException.ReferenceEquals(person, $"The person with id {id} was not found.");

            _logger.LogInformation($"Deleted person.", person);
            await _personRepository.DeleteAsync(person);
        }

        public async Task<IEnumerable<PersonDto>> GetAll()
         {
            var data = await _personRepository.FindAllAsync();
            return _mapper.Map<IEnumerable<PersonDto>>(data);   
        }

        public async Task<Person> GetById(int id)
        {
            return await _personRepository.FindByIdAsync(id);
        }

        public async Task<Person> Update(int id, PersonDto personDTO)
        {
            var person = await _personRepository.FindByIdAsync(id);


            // Not using AutoMapper here because it can cause issues with EF Core
            person.Name = personDTO.Name;
            person.Phone = personDTO.Phone;
            person.Email = personDTO.Email;

            await _personRepository.UpdateAsync(person);

            _logger.LogInformation("Updated person with name {person.Name} and ID {person.Id}", person.Name, person.Id);

            return person;
        }

    }

}