using Homie.API.Models;
using Homie.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Homie.API.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private readonly HomieDbContext _homieDbContext;

        public FoodRepository(HomieDbContext homieDbContext)
        {
            _homieDbContext = homieDbContext;
        }

        public List<Food> GetAllFood()
        {
            return _homieDbContext.Food.OrderBy(x => x.FoodName).ToList();
        }

        public async void Add(Food food)
        {
            food.Id = Guid.NewGuid();
            _homieDbContext.Food.Add(food);
            _homieDbContext.SaveChanges();
        }

        public void Update(Food food)
        {
            _homieDbContext.Food.Update(food);
            _homieDbContext.SaveChanges();
        }

        public void Delete(Guid foodId)
        {
            var foodToRemove = GetById(foodId);
            if (foodToRemove != null)
            {
                _homieDbContext.Food.Remove(foodToRemove);
                _homieDbContext.SaveChanges();
            }
        }

        public Food? GetById(Guid? foodId)
        {
            return _homieDbContext.Food.Find(foodId);
        }
    }
}