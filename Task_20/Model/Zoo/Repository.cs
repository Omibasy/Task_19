using System.Collections.Generic;
using System.Linq;

namespace Task_20.Model.Zoo
{
     class Repository 
    {
       List<IAnimal> animals;

        public Repository()
        { 
           animals = new List<IAnimal>();           
        }

        public List<IAnimal> GetAnimals()
        {
            return animals;
        }

        public Repository(IEnumerable<IAnimal> Сreatures)
        {
            animals = Сreatures.ToList<IAnimal>();          
        }

        public string [] EnumerationAnimals()
        {
            string[] animalsDate = new string[animals.Count];   

            for (int i = 0; i < animals.Count; i++)
            {
                animalsDate[i] = animals[i].ToString();
            }

            return animalsDate;
        }
    }
}
