namespace GSC_API.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Rol Rol { get; set; }
        public int RolId { get; set; }

    }
}
