using AutoMapper;
using Entities.DTO.Request.Person;
using Entities.Entity;
using System.Diagnostics.CodeAnalysis;

namespace Entities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Request DTO to Entity

            CreateMap<Person, PersonDto>().ReverseMap();

            #endregion
        }
    }
}