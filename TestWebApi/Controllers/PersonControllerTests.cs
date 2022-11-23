using AutoMapper;
using GSC_API.Controllers;
using GSC_API.DataAccess;
using GSC_API.Dto;
using GSC_API.Entities;
using GSC_API.Utils;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace TestWebApi.Controllers
{
    public class PersonControllerTests
    {
        private Mock<IPersonRepository> _mockRepo;
        //private PersonController _controller;
        private IMapper _mapper;

        public PersonControllerTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapperProfiles());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            _mockRepo = new Mock<IPersonRepository>();

            //_controller = new PersonController(_mockRepo.Object, _mapper);
        }

        [Fact]
        public void GetAll_PersonsAll()
        {
            //arrange
            var personList = GetPersonsData();
            _mockRepo.Setup(x => x.GetAll()).Returns(personList);
            var personController = new PersonController(_mockRepo.Object, _mapper);

            //act
            var personResult = personController.GetAll();

            //assert
            Assert.NotNull(personResult);
            Assert.NotNull(GetPersonsData());
            Assert.IsType<List<Person>>(personResult);
        }


        [Fact]
        public void GetPersonByID_Person()
        {
            //arrange
            var personlist = GetPersonsData();
            _mockRepo.Setup(x => x.GetById(2))
                .Returns(personlist[1]);
            var personController = new PersonController(_mockRepo.Object, _mapper);

            //act
            var personResult = personController.GetById(2);
            ActionResult<Person> personReturn = personlist[1];


            //assert
            Assert.NotNull(personResult);            
            Assert.IsType<ActionResult<Person>>(personResult);
        }

        [Fact]
        public void AddPerson_Person()
        {
            //arrange
            var person = new PersonDto
            {                
                Name = "Soledad Sanchez",
                PhoneNumber = "341212134",
                EmailAddress = "ssanchez@fake.com",
            };
            _mockRepo.Setup(x => x.Add(person))
                .Returns(_mapper.Map<Person>(person));
            var personController = new PersonController(_mockRepo.Object, _mapper);

            //act
            var personResult = personController.Add(person);

            //assert
            Assert.NotNull(personResult);
            Assert.IsNotType<ActionResult<PersonDto>>(personResult);
            Assert.IsType<ActionResult<Person>>(personResult);
        }

        private List<Person> GetPersonsData()
        {
            List<Person> personsData = new List<Person>
        {
            new Person
            {
                Id = 1,
                Name = "Pablo E Rastelli",
                PhoneNumber = "3415312748",
                EmailAddress = "prastelli@fake.com",
            },
             new Person
            {
                Id = 2,
                Name = "Lucia Rastelli",
                PhoneNumber = "11111111",
                EmailAddress = "lrastelli@fake.com",
            },
            new Person
            {
                Id = 3,
                Name = "Luca Rastelli",
                PhoneNumber = "22222222",
                EmailAddress = "lucarastelli@fake.com",
            },
            new Person
            {
                Id = 4,
                Name = "Juan Rastelli",
                PhoneNumber = "33333333",
                EmailAddress = "juanrastelli@fake.com",
            },
            new Person
            {
                Id = 5,
                Name = "Luly Rastelli",
                PhoneNumber = "444444444",
                EmailAddress = "lulyrastelli@fake.com",
            },
        };

            return personsData;
        }


    }
}
