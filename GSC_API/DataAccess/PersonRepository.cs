using AutoMapper;
using GSC_API.Dto;
using GSC_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GSC_API.DataAccess
{
    public class PersonRepository : IPersonRepository
    {
        private readonly LoanDBContext _context;
        private readonly IMapper _mapper;

        public PersonRepository(LoanDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Person Add(PersonDto entity)
        {
            var person = _mapper.Map<Person>(entity);
            var savedEntity = _context.People.Add(person);
             _ = _context.SaveChanges();
            return savedEntity.Entity;
        }

        public bool Delete(int id)
        {
            var person = _context.People.Find(id);
            
            if (person == null) {
                return false;
            }
            _context.People.Remove(person);
            _context.SaveChanges();

            return true;
        }

        public List<Person> GetAll()
        {
            
            return _context.People.ToList();
        }

        public Person? GetById(int id)
        {
            var person = _context.People.Find(id);
            if (person == null) throw new KeyNotFoundException("Person not found");

            return person;
        }

        public void Update(Person entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();            
        }
    }
}
