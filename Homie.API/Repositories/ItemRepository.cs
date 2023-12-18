using Homie.API.Models;
using Homie.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Homie.API.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly HomieDbContext _homieDbContext;

        public ItemRepository(HomieDbContext homieDbContext)
        {
            _homieDbContext = homieDbContext;
        }

        public List<Item> GetItems()
        {
            return _homieDbContext.Items.OrderBy(x => x.ItemName).ToList();
        }

        public void Add(Item item)
        {
            item.Id = Guid.NewGuid();
            _homieDbContext.Items.Add(item);
            _homieDbContext.SaveChanges();
        }

        public void Update(Item item)
        {
            _homieDbContext.Items.Update(item);
            _homieDbContext.SaveChanges();
        }

        public void Delete(Guid itemId)
        {
            var itemToRemove = GetById(itemId);
            if (itemToRemove != null)
            {
                _homieDbContext.Remove(itemToRemove);
                _homieDbContext.SaveChanges();
            }
        }

        public Item? GetById(Guid itemId)
        {
            return _homieDbContext.Items.Find(itemId);
        }

        public List<Item> GetByPlaceId(Guid placeId)
        {
            return _homieDbContext.Items.Where(x => x.PlaceId == placeId).OrderBy(x => x.ItemName).ToList();
        }
    }
}