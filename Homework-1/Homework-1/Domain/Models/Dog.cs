using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Dog : Pet
    {
        public string FavoriteFood { get; set; }

        public override string PrintInfo()
        {
            return $"Name: {Name} - Type: {Type} - Age: {Age}\n";
        }
    }
}
