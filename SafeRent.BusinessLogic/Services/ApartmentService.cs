using System.Collections.Generic;
using SafeRent.BusinessLogic.Services.Interfaces;
using SafeRent.DataAccess.Models;
using SafeRent.DataAccess.Repositories.Interfaces;

namespace SafeRent.BusinessLogic.Services
{
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository _repository;

        public ApartmentService(IApartmentRepository repository)
        {
            _repository = repository;
        }
        
        public void Add(Apartment apartment)
        {
            _repository.Add(apartment);
        }

        public void Delete(int apartmentId)
        {
            _repository.Delete(apartmentId);
        }

        public void Update(Apartment updatedApartment)
        {
            _repository.Update(updatedApartment);
        }

        public Apartment GetById(int apartmentId)
        {
            return _repository.GetById(apartmentId);
        }

        public ICollection<Apartment> GetAllApartments()
        {
            return _repository.GetAllApartments();
        }
    }
}