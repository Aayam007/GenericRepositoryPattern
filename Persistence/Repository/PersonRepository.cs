using Entities.DTO.Request.Person;
using Entities.Entity;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Interfaces;
using Persistence.Repository.GenericRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(ApiContext apiContext)
            : base(apiContext)
        {

        }


        public async Task<List<Person>> GetPeopleAsync(List<int> ids)
        {
            return (await Context.Set<Person>().Where(p => ids.Any(id => id == p.Id)).ToListAsync());
        }
    }
}