using SQLite;

namespace MauiApp1.Models
{
    public class Photo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
}
