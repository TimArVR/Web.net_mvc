namespace WebNETFirstProj.Models
{
    public class Navigation
    {
        const int number = 10;
        public int FoundItems { get; set; }
        public int CurrentPage { get; set; }
        public string? PageName { get; set; }
        public int Pages { get { return FoundItems / number; } }
    }
}
