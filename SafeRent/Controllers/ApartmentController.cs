using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SafeRent.BusinessLogic.Services.Interfaces;
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
            return _apartmentService.GetById(id);
        }
    }
}