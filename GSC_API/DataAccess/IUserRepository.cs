using GSC_API.Dto;
using GSC_API.Entities;
using GSC_API.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GSC_API.DataAccess
{
    public interface IUserRepository
    {
        User Add(UserViewModel entity);
        bool Delete(int id);

        void Update(User entity);
        User? GetById(int id);

        List<User> GetAll();
    }
}
