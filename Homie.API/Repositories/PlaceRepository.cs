using Homie.API.Models;
using Homie.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Homie.API.Repositories
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly HomieDbContext _homieDbContext;

        public PlaceRepository(HomieDbContext homieDbContext)
        {
            _homieDbContext = homieDbContext;
        }

        public List<Place> GetPlaces()
        {
            return _homieDbContext.Places.OrderBy(x => x.PlaceName).ToList();
        }

        public void Add(Place place)
        {
            place.Id = Guid.NewGuid();
            _homieDbContext.Places.Add(place);
            _homieDbContext.SaveChanges();
        }

        public void Update(Place place)
        {
            _homieDbContext.Places.Update(place);
            _homieDbContext.SaveChanges();
        }

        public void Delete(Guid placeId)
        {
            var placeToRemove = GetById(placeId);
            if (placeToRemove != null)
            {
                _homieDbContext.Places.Remove(placeToRemove);
                _homieDbContext.SaveChanges();
            }
        }

        public Place? GetById(Guid? placeId)
        {
            return _homieDbContext.Places.Find(placeId);
        }
    }
}