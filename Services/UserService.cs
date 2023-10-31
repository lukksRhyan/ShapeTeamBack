using ShapeTeamBack.Models;
namespace ShapeTeamBack.Services
{

    public class UserService
    {
        static List<User> Users { get; }
        static int nextId = 0;
        static UserService() 
        {
            Users = new List<User>();
        }

        public static List<User>GetAll() => Users;
        public static User? Get(int id) => Users.FirstOrDefault(x => x.Id == id);

        public static void Add(User user)
        {
            user.Id = nextId++;
            Users.Add(user);
        }
        public static void Update(User user) {
            var index = Users.FindIndex(x => x.Id == user.Id);
            if (index == -1) { return; }
            Users[index] = user;
        }
        public static void Delete(int id) {
            var user = Get(id);
            if(user is null) { return; }
            Users.Remove(user);
        }
    }
}
