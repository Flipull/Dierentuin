using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZooLibrary.Model
{
    public class Monkey : Animal
    {

        [Key]
        public override int Id { get; set; }

        public Monkey()
        {
            Name = AnimalNamingConventions.PickName(AnimalNamingConventions.MonkeyNames);
            Energy = 20;
            EatAmount = 10;
            UseAmount = 2;
        }

    }
}
