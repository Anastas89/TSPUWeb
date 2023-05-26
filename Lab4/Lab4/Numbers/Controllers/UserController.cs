using DataBase.Services.Users;
using Microsoft.AspNetCore.Mvc;
using DataBase;



namespace Numbers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DbUser>> Get()
        {
            DbUser[] data = userRepository.Get();
            return data;
        }

        [HttpGet("{id}")]  
        public ActionResult<DbUser> Get([FromRoute] int id)
        {
            var user = userRepository.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public ActionResult Post([FromBody] DbUser user)
        {

            userRepository.Create(user);
            return Ok();
        }

        [HttpPut]
        public ActionResult Update([FromBody] DbUser user)
        {
              userRepository.Update(user);
              return Ok();
          }

        [HttpDelete("{index}")]  
          public ActionResult Delete([FromRoute] int id)
          {
              userRepository.Delete(id);
              return Ok();
          }
    }
}