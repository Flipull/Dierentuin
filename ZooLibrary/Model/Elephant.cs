using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZooLibrary.Model
{
    public class Elephant : Animal
    {
        [Key]
        public override int Id { get; set; }
        
        public Elephant()
        {
            Name = AnimalNamingConventions.PickName(AnimalNamingConventions.ElephantNames);
            Energy = 10;
            EatAmount = 50;
            UseAmount = 5;
        }
    }
}
