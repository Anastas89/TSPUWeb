using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    [Route("api/controller")]
    public class TestController : Controller
    {


        [HttpGet("{count}")]
        public ActionResult<int[]> Get([FromRoute] int count)
        {
            int[] array = new int[count];
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = rand.Next();
            return Ok(array);
        }
    }
}
