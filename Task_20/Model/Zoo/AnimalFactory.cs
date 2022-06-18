
namespace Task_20.Model.Zoo
{
    static class AnimalFactory
    {
        public static IAnimal GetAnimal(string viewAnimal, string breed, string name, string features)
        {
            string value;

            if (viewAnimal == null)
            {
                value = "";
            }
            else
            {
                value = viewAnimal.Trim();
            }
            switch (value)
            {
                case "млекопитающие":
                    return new Mammals(viewAnimal, breed, name, features);

                case "птица":
                    return new Birds(viewAnimal, breed, name, features);

                case "земноводное":
                    return new Amphibians(viewAnimal, breed, name, features);

                default: return new UnknownAnimals();

            }      
        }
    }
}
