namespace ShapeTeamBack.Models
{
    public class Gym
    {
        public int Id { get; set; }
        public string? name { get; set; }
        public List<User>? members {  get; set; }
        //public Local localizacao
        public Gym() { }
    }
}
