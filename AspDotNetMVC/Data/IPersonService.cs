namespace AspDotNetCoreMVC.Data
{
    public interface IPersonService
    {
        public IEnumerable<Person> GetAll();
    }
}
