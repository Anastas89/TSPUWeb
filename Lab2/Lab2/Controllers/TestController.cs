using Lab2.folder_class;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace Lab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        [HttpGet]
        public ActionResult<User[]> Get()
        {
            User[] data = Repository.GetData();
            return data;
        }

        [HttpGet("{index}")]
        public ActionResult<User[]> Get([FromRoute] int index)
        {
            var data = Repository.GetData(index);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }


        [HttpDelete("{index}")]
        public ActionResult Delete([FromRoute] int index)
        {

            Repository.Delete(index);
            return Ok();
        }


        [HttpPost]
        public ActionResult Post([FromBody] AddUserContract contract)
        {
            User user = new User()
            {
                Login = contract.Login,
                UserName = contract.UserName
            };
            Repository.Add(user);
            return Ok();
        }

        [HttpPut("{index}")]
        public ActionResult Put([FromBody] AddUserContract contract, int index)
        {

            User user = new User()
            {
                Login = contract.Login,
                UserName = contract.UserName
            };


            Repository.Update(user, index);
            return Ok();
        }

    }
}
