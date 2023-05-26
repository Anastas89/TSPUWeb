using DataBase.Services.Users;
using Microsoft.AspNetCore.Mvc;
using DataBase;

namespace lab6.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly IUserPurchaseRepository purchaseRepository;

        public PurchaseController(IUserPurchaseRepository purchaseRepository)
        {
            this.purchaseRepository = purchaseRepository;
        }

        [HttpGet("{id}")] 
        public ActionResult<UserPurchase> Get([FromRoute] int id)
        {
            var user = purchaseRepository.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        [HttpPost]
        public ActionResult Post([FromBody] UserPurchase userpurchase)
        {

            purchaseRepository.Create(userpurchase);
            return Ok();
        }
    }
}