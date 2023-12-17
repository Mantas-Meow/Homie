using Homie.API.Models;
using Homie.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Homie.API.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly HomieDbContext _homieDbContext;

        public IngredientRepository(HomieDbContext homieDbContext)
        {
            _homieDbContext = homieDbContext;
        }

        public List<Ingredient> GetAllIngredients()
        {
            return _homieDbContext.Ingredient.OrderBy(x => x.FoodName).ToList();
        }

        public async void Add(Ingredient food)
        {
            food.Id = Guid.NewGuid();
            _homieDbContext.Ingredient.Add(food);
            _homieDbContext.SaveChanges();
        }

        public void Update(Ingredient food)
        {
            _homieDbContext.Ingredient.Update(food);
            _homieDbContext.SaveChanges();
        }

        public void Delete(Guid foodId)
        {
            var foodToRemove = GetById(foodId);
            if (foodToRemove != null)
            {
                _homieDbContext.Ingredient.Remove(foodToRemove);
                _homieDbContext.SaveChanges();
            }
        }

        public Ingredient? GetById(Guid? foodId)
        {
            return _homieDbContext.Ingredient.Find(foodId);
        }
    }
}