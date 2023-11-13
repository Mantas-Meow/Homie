using Homie.API.DTOs.Place;
using Homie.API.Models;
using Homie.API.Repositories.Interfaces;
using Homie.API.Services.Interfaces;

namespace Homie.API.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository _placeRepository;

        public PlaceService(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        public List<PlaceResponseBody> GetPlaces()
        {
            var repoPlaces = _placeRepository.GetPlaces();
            var places = new List<PlaceResponseBody>();

            foreach (var place in repoPlaces)
            {
                places.Add(new PlaceResponseBody(place.Id, place.PlaceName, place.Description, place.Room, place.Furniture, place.LastUpdated));
            }
            return places;
        }

        public PlaceResponseBody? GetPlaceById(Guid placeId)
        {
            var place = _placeRepository.GetById(placeId);
            if (place == null)
            {
                return null;
            }
            return new PlaceResponseBody(place.Id, place.PlaceName, place.Description, place.Room, place.Furniture, place.LastUpdated);
        }

        public void AddPlace(CreatePlaceRequestBody place)
        {
            _placeRepository.Add(new Place(place.PlaceName, place.Description, place.Room, place.Furniture, place.LastUpdated));
        }

        public void UpdatePlace(Guid placeId, UpdatePlaceRequestBody place)
        {
            var existingItem = _placeRepository.GetById(placeId);
            if (existingItem != null)
            {
                existingItem.PlaceName = place.PlaceName;
                existingItem.Description = place.Description;
                existingItem.Room = place.Room;
                existingItem.Furniture = place.Furniture;
                existingItem.LastUpdated = new DateTime();

                _placeRepository.Update(existingItem);
            }
        }

        public void DeletePlace(Guid itemId)
        {
            _placeRepository.Delete(itemId);
        }
    }
}
