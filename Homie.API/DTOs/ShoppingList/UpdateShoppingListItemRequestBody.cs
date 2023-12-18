namespace Homie.API.DTOs.ShoppingList
{
    public class UpdateShoppingListItemRequestBody
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Double Amount { get; set; }
        public Boolean IsBought { get; set; }
    }
}
