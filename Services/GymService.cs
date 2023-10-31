using ShapeTeamBack.Models;
namespace ShapeTeamBack.Services
{

    public class GymService
    {
        static List<Gym> Gyms { get; }
        static int nextId = 0;
        static GymService()
        {
            Gyms = new List<Gym>();
        }

        public static List<Gym> GetAll() => Gyms;
        public static Gym? Get(int id) => Gyms.FirstOrDefault(x => x.Id == id);

        public static void Add(Gym gym)
        {
            gym.Id = nextId++;
            Gyms.Add(gym);
        }
        public static void Update(Gym gym)
        {
            var index = Gyms.FindIndex(x => x.Id == gym.Id);
            if (index == -1) { return; }
            Gyms[index] = gym;
        }
        public static void Delete(int id)
        {
            var gym = Get(id);
            if (gym is null) { return; }
            Gyms.Remove(gym);
        }
    }
}
