using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Cat : Pet
    {
        public string Lazy { get; set; }
        public int LivesLeft { get; set; }

        public override string PrintInfo()
        {
            return $"Name: {Name} - Type: {Type} - Age: {Age}\n";
        }

    }
}
