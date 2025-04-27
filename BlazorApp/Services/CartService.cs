namespace BlazorApp.Services
{
    public class CartService : ICartService
    {
        private List<Item> _cartItems = new List<Item>();
        public event Action<int>? OnItemAdded;
        public int GetItemCount()
        {
            return _cartItems.Count;
        }
        public void AddToCart(Item item)
        {
            _cartItems.Add(item);
            OnItemAdded?.Invoke(_cartItems.Count);
        }
    }


}
