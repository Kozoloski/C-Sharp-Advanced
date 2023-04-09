using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Fish : Pet
    {
        public string Color { get; set; }
        public int Size { get; set; }

        public override string PrintInfo()
        {          
            return $"Name: {Name} - Type: {Type} - Age: {Age}";
        }
    }
}
