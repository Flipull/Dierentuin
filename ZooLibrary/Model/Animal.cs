using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZooLibrary.Model
{
    public abstract class Animal
    {
        public Animal()
        {
        }

        public abstract int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [NotMapped]
        private int _energy;
        [Required]
        public int Energy {
            //todo: bugfix
            get { return _energy; }
            set 
            {
                if (value == _energy) //
                    return; 
                _energy = Math.Max(0, Math.Min(100, value));
            }
        }

        [NotMapped]
        public int EatAmount { get; set; }

        [NotMapped]
        public int UseAmount { get; set; }

        [NotMapped]
        public bool IsAlive { get { return Energy > 0; } }
        [NotMapped]
        public bool IsFull { get { return Energy >= 100; } }
        
        public bool Eat()//feed-function
        {
            if (!IsAlive || IsFull)
                return false;
            
            Energy += EatAmount;
            return true;
        }

        public void UseEnergy()//tick-function
        {
            Energy -= UseAmount;
        }
        
    }
}
