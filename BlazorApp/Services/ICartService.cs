using System.ComponentModel;

namespace BlazorApp.Services
{
    public interface ICartService
    {
        public int GetItemCount();
        public void AddToCart(Item item);

        event Action<int> OnItemAdded;
    }

    public record Item(int Id, string Name);
}
