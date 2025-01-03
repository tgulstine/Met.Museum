namespace Met.Museum.Data
{
    public class SearchHistory : BaseEntity
    {
        public Uri? SearchUrl { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
