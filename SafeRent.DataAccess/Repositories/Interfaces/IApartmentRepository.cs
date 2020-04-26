using SafeRent.DataAccess.Models;

namespace SafeRent.DataAccess.Repositories.Interfaces
{
    public interface IApartmentRepository
    {
        void Add(Apartment apartment);
        void Delete(int apartmentId);
        void Update(int apartmentId, Apartment updatedApartment);
        Apartment GetById(int apartmentId);
    }
}