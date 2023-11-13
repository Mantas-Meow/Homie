using Homie.API.Models;

namespace Homie.API.Repositories.Interfaces
{
    public interface IPlaceRepository
    {
        public List<Place> GetPlaces();
        public void Add(Place place);
        public void Update(Place place);
        public void Delete(Guid placeId);
        public Place? GetById(Guid? placeId);
    }
}
