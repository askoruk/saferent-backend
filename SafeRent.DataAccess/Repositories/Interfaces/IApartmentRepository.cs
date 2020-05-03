using System.Collections.Generic;
using SafeRent.DataAccess.Models;

namespace SafeRent.DataAccess.Repositories.Interfaces
{
    public interface IApartmentRepository
    {
        void Add(Apartment apartment);
        void Delete(int apartmentId);
        void Update(Apartment updatedApartment);
        Apartment GetById(int apartmentId);
        ICollection<Apartment> GetAllApartments();
        void AddUserToApartment(string userId, int apartmentId);
    }
}