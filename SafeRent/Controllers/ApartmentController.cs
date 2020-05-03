using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SafeRent.BusinessLogic.Services.Interfaces;
using SafeRent.BusinessLogic.Models;
using SafeRent.DataAccess.Models;

namespace SafeRent.Controllers
{
    [Route("[controller]")]
    public class ApartmentController : Controller
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }
        
        [HttpPost]
        public IActionResult Post([FromBody]Apartment apartment)
        {
            _apartmentService.Add(apartment);
            return Ok();
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<Apartment> Get(int id)
        {
            return Ok(_apartmentService.GetById(id));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Apartment updatedApartment)
        {
            _apartmentService.Update(updatedApartment);
            return Ok();
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _apartmentService.Delete(id);
            return Ok();
        }

        [Route("getall")]
        [HttpGet]
        public ActionResult<ICollection<Apartment>> Get()
        {
            return Ok(_apartmentService.GetAllApartments());
        }

        [Route("adduser")]
        [HttpPost]
        public ActionResult AddUserToApartment([FromBody]UserToApartmentModel model)
        {
            _apartmentService.AddUserToApartment(model);
            return Ok();
        }

        [Route("getforuser/{userId}")]
        [HttpGet]
        public ActionResult<List<Apartment>> GetApartmentsForUser(string userId)
        {
            return _apartmentService.GetApartmentsForUser(userId);
        }
    }
}