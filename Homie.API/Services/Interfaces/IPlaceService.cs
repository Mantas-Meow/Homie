using Homie.API.DTOs.Place;

namespace Homie.API.Services.Interfaces
{
    public interface IPlaceService
    {
        public List<PlaceResponseBody> GetPlaces();
        public PlaceResponseBody? GetPlaceById(Guid placeId);
        public void AddPlace(CreatePlaceRequestBody place);
        public void UpdatePlace(Guid placeId, UpdatePlaceRequestBody place);
        public void DeletePlace(Guid itemId);
    }
}
