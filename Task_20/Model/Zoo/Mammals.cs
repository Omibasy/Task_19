using System;
using System.Collections.Generic;


namespace Task_20.Model.Zoo
{
    class Mammals : IAnimal
    {

        static int count;

        public Mammals() { count = 1; }

        public Mammals(string viewAnimal, string breed, string name, string features)
        {
            ViewAnimal = viewAnimal;
            Breed = breed;
            Name = name;
            Features = features;

            count++;
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
