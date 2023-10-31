using ShapeTeamBack.Models;
namespace ShapeTeamBack.Services
{

    public class EventService
    {
        static List<Event> Events { get; }
        static int nextId = 0;
        static EventService()
        {
            Events = new List<Event>();
        }

        public static List<Event> GetAll() => Events;
        public static Event? Get(int id) => Events.FirstOrDefault(x => x.Id == id);

        public static void Add(Event evento)
        {
            evento.Id = nextId++;
            Events.Add(evento);
        }
        public static void Update(Event evento)
        {
            var index = Events.FindIndex(x => x.Id == evento.Id);
            if (index == -1) { return; }
            Events[index] = evento;
        }
        public static void Delete(int id)
        {
            var evento = Get(id);
            if (evento is null) { return; }
            Events.Remove(evento);
        }
    }
}
