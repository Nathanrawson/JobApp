namespace JobApp.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string? Position { get; set; }
        public string? Description { get; set; }
        public DateTime DatePosted { get; set; }
        public DateTime DateUpdated { get; set; }
        public int Version { get; set; }
    }
}
