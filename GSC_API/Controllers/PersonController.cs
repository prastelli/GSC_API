using Microsoft.AspNetCore.Mvc;
using GSC_API.DataAccess;
using GSC_API.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using GSC_API.Dto;
using AutoMapper;
using System.Security.Policy;

namespace GSC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly PersonRepository _personRepository;
        private IMapper _mapper;

        public PersonController(PersonRepository personRepository,IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        [Authorize(Roles = "Admin,User", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<IEnumerable<Person>> GetAll()
        {
            return _personRepository.GetAll();
        }

        [HttpGet("GetById/{id}")]        
        [Authorize(Roles = "Admin,User")]
        public ActionResult<Person> GetById(int id)
        {
            var person = _personRepository.GetById(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        [HttpPut("Update/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, [FromBody] Person entity)
        {
            if (id != entity.Id) {
                return BadRequest("URL id does NOT match Body one.");
            }

            _personRepository.Update(entity);

            return NoContent();
        }

        [HttpPost("Add")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Person> Add([FromBody] PersonDto person)
        {
            return CreatedAtAction("NewPerson", _personRepository.Add(person));
        }

      
        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public  IActionResult DeletePerson(int id)
        {
            var Deleted = _personRepository.Delete(id);

            if (Deleted)
            {
                return NoContent();                
            }
            return NotFound();
        }

    }
}
