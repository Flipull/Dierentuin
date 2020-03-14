using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooLibrary.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspCoreZoo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedingController : BaseController
    {
        public FeedingController(ZooContext db_context) : base(db_context) { }

        // GET: api/<controller>
        [HttpGet]
        [HttpPost]
        public IActionResult Get() => throw new InvalidOperationException();

        // POST api/<controller>/All
        [HttpPost]
        [Route("All")]
        public uint All()
        {
            return FeedTypedAnimals<Animal>();
        }
        // POST api/<controller>/Monkeys
        [HttpPost]
        [Route("Monkeys")]
        public uint Monkeys()
        {
            return FeedTypedAnimals<Monkey>();
        }
        // POST api/<controller>/Lions
        [HttpPost]
        [Route("Lions")]
        public uint Lions()
        {
            return FeedTypedAnimals<Lion>();
        }
        // POST api/<controller>/Elephants
        [HttpPost]
        [Route("Elephants")]
        public uint Elephants()
        {
            return FeedTypedAnimals<Elephant>();
        }

        private uint FeedTypedAnimals<T>()
        {
            var all_typed_animals = _context.Animals.Where(a => a is T).AsEnumerable();
            uint total_feeded = FeedAnimals(all_typed_animals);
            _context.SaveChanges();
            return total_feeded;
        }

        private uint FeedAnimals(IEnumerable<Animal> subjects)
        {
            uint counter = 0;
            foreach (var animal in subjects)
            {
                if (animal.Eat() )
                    counter++;
            }
            return counter;
        }

    }
}
