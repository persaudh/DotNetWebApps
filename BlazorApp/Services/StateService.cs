namespace BlazorApp.Services
{
    public class StateService : IStateService
    {
        public IEnumerable<State> GetStates()
        {
            return new List<State>
            {
                new State { Name = "Alabama", Abbreviation = "AL" },
                new State { Name = "Alaska", Abbreviation = "AK" },
                new State { Name = "Arizona", Abbreviation = "AZ" },
                new State { Name = "Arkansas", Abbreviation = "AR" },
                new State { Name = "California", Abbreviation = "CA" },
                new State { Name = "Colorado", Abbreviation = "CO" },
                new State { Name = "Connecticut", Abbreviation = "CT" },
                new State { Name = "Delaware", Abbreviation = "DE" },
                new State { Name = "Florida", Abbreviation = "FL" },
                new State { Name = "Georgia", Abbreviation = "GA" },
                new State { Name = "Hawaii", Abbreviation = "HI" },
                new State { Name = "Idaho", Abbreviation = "ID" },
                new State { Name = "Illinois", Abbreviation = "IL" },
                new State { Name = "Indiana", Abbreviation = "IN" },
                new State { Name = "Iowa", Abbreviation = "IA" },
                new State { Name = "Kansas", Abbreviation = "KS" },
                new State { Name = "Kentucky", Abbreviation = "KY" },
                new State { Name = "Louisiana", Abbreviation = "LA" },
                new State { Name = "Maine", Abbreviation = "ME" }
                // Add more states as needed

            };
        }
    }
    public class State
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }


    }
}
