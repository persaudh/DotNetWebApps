using AspDotNetCoreMVC.Data;

namespace AspDotNetCoreMVC.Models
{
    public class PersonViewModel
    {
        public string Name{ get; set; }
        public int Age { get; set; }
        public PersonViewModel(Person person)
        {
            Name = $"{person.FirstName} {person.LastName}";
            Age = DateTime.Now.Year - person.DateOfBirth.Year;
        }
    }
}
