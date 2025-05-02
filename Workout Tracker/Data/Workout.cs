namespace WorkoutTracker.Data
{
    public class Workout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rep { get; set; }
        public int Weight {  get; set; }
        public int Sets { get; set; }

        public string DayOfTheWeek { get; set; }

        public Workout()
        {

        }

        public Workout(int id, string name, string description, int rep, int weight, int sets, string dayOfTheWeek)
        {
            Id = id;
            Name = name;
            Description = description;
            Rep = rep;
            Weight = weight;
            Sets = sets;
            DayOfTheWeek = dayOfTheWeek;
        }
    }
}
