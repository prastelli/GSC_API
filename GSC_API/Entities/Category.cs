using System.ComponentModel.DataAnnotations;

namespace GSC_API.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public IList<Thing> Things { get; set; }

    }
}
