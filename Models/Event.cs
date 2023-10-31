namespace ShapeTeamBack.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime dateTime { get; set; }

        public Event(int id, string Name, string Description, DateTime dateTime)
        {
            Id = id;
            this.Name = Name;
            this.Description = Description;
            this.dateTime = dateTime;
        }
    }
}
