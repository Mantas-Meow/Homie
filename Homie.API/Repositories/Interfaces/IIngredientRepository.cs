using Homie.API.Models;

namespace Homie.API.Repositories.Interfaces
{
    public interface IIngredientRepository
    {
        public List<Ingredient> GetAllIngredients();
        public void Add(Ingredient food);
        public void Update(Ingredient food);
        public void Delete(Guid foodId);
        public Ingredient? GetById(Guid? foodId);
    }
}
