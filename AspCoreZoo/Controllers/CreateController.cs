using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZooLibrary.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspCoreZoo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreateController : BaseController
    {
        public CreateController(ZooContext db_context) : base(db_context) { }

        // GET: /api/<controller>/
        [HttpGet]
        [HttpPost]
        public IActionResult Index() => throw new InvalidOperationException();
        

        // POST: /api/<controller>/Monkey
        [HttpPost]
        [Route("Monkey")]
        public Animal Monkey(string name)
        {
            Monkey new_monkey = new Monkey()
            {
            };

            _context.Animals.Add(new_monkey);
            _context.SaveChanges();
            return new_monkey;
        }

        // POST: /api/<controller>/Lion
        [HttpPost]
        [Route("Lion")]
        public Animal Lion()
        {
            Lion new_lion = new Lion()
            {
            };
            
            _context.Animals.Add(new_lion);
            _context.SaveChanges();
            return new_lion;
        }

        // POST: /api/<controller>/Elephant
        [Route("Elephant")]
        [HttpPost]
        public Animal Elephant()
        {
            Elephant new_elephant = new Elephant()
            {
            };

            _context.Animals.Add(new_elephant);
            _context.SaveChanges();
            return new_elephant;
        }
    }
}
