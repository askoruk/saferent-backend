using System.Collections.Generic;
using SafeRent.DataAccess.Models;

namespace SafeRent.BusinessLogic.Services.Interfaces
{
    public interface IApartmentService
    {
        void Add(Apartment apartment);
        void Delete(int apartmentId);
        void Update(Apartment updatedApartment);
        Apartment GetById(int apartmentId);
        ICollection<Apartment> GetAllApartments();
    }
}