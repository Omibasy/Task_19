using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_20.Model.Zoo
{
    class UnknownAnimals : IAnimal
    { 
        public UnknownAnimals()
        {
            ViewAnimal = "Неизвестныый вид";
            Breed = "Неизвестныый вид";
            Name = "Неизвестныый вид";
            Features = "Неизвестныый вид";
        }

        public string Name { get; set; }
        public string ViewAnimal { get; set; }
        public string Breed { get; set; }
        public string Features { get; set; }

        public override string ToString()
        {
            return $"{ViewAnimal} | {Breed} | {Name} | {Features}";
        }
    }
}
