using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZooLibrary.Model
{
    public sealed class Lion : Animal
    {

        [Key]
        public override int Id { get; set; }

        public Lion()
        {
            Name = AnimalNamingConventions.PickName(AnimalNamingConventions.LionNames);
            Energy = 10;
            EatAmount = 25;
            UseAmount = 10;
        }

    }
}
