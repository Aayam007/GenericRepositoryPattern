using Entities.Entity;
using Persistence.Interfaces.GenericRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Interfaces
{

    public interface IPersonRepository : IGenericRepository<Person>
    {
        Task<List<Person>> GetPeopleAsync(List<int> ids);
    }
}
