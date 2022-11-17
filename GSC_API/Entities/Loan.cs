namespace GSC_API.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool Status { get; set; }
        public Thing Thing { get; set; }
        public Person Person { get; set; }
    }
}
