using Homie.API.DTOs.Place;

namespace Homie.API.Services.Interfaces
{
    public interface IPlaceService
    {
        public Task<List<PlaceResponseBody>> GetPlaces();
        public Task<PlaceResponseBody?> GetPlaceById(Guid placeId);
        public Task AddPlace (CreatePlaceRequestBody place);
        public Task UpdatePlace (Guid placeId, UpdatePlaceRequestBody place);
        public Task DeletePlace (Guid itemId);
    }
}
