using GSC_API.Entities;
using GSC_API.Models;

namespace GSC_API.DataAccess
{
    public interface IThingRepository
    {
        Thing Add(ThingsViewModel entity);
        bool Delete(int id);

        void Update(Thing entity);
        Thing? GetById(int id);

        List<Thing> GetAll();
    }
}
