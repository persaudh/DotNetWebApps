namespace BlazorApp.Services
{
    public interface IStateService
    {
        public IEnumerable<State> GetStates();
    }
}
