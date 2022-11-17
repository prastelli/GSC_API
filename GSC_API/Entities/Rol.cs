namespace GSC_API.Entities
{
    public class Rol
    {
        public int Id { get; set; }
        public string RolDescription { get; set; }
        public User User { get; set; }
    }
}
