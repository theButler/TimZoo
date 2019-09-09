using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimZoo.Models;

namespace TimZoo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZooController : ControllerBase
    {
        private readonly ZooContext _context;

        public ZooController(ZooContext context)
        {
            _context = context;

            if (_context.Animals.Count() == 0)
            {
                Zoo theZoo = new Zoo(_context);
                theZoo.GetAnimals();
            }
        }

        // GET: api/Zoo
        [HttpGet]
        public  ActionResult<List<Animal>> GetAnimals()
        {
            Zoo theZoo = new Zoo(_context);
            return  theZoo.GetAnimals();
        }

        // POST: api/Zoo
        [HttpPost("updatezoo")]
        public ActionResult<List<Animal>> UpdateZoo()
        {
            Zoo theZoo = new Zoo(_context);
            return theZoo.ProgressOneHour();
        }

        // POST: api/Zoo
        [HttpPost("feedzoo")]
        public ActionResult<List<Animal>> FeedZoo()
        {
            Zoo theZoo = new Zoo(_context);
            return theZoo.FeedZoo();
        }
    }
}