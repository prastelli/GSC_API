using GSC_API.Dto;
using GSC_API.Entities;

namespace GSC_API.DataAccess
{
    public interface IPersonRepository
    {
        Person Add(PersonDto entity);
        bool Delete(int id);

        void Update(Person entity);
        Person? GetById(int id);

        List<Person> GetAll();
    }
}
