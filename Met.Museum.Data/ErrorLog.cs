namespace Met.Museum.Data
{
    public class ErrorLog : BaseEntity
    {
        public string? ErrorMessage { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
