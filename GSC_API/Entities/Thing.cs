namespace GSC_API.Entities
{
    public class Thing
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
