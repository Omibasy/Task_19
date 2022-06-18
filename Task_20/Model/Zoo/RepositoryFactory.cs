using Task_20.Model.Load;

namespace Task_20.Model.Zoo
{
    static class RepositoryFactory
    {
        public static Repository GetRepository(ILoadAnimal listAnimals)
        {
            return new Repository(listAnimals.GetAnimalsData()); ;
        }
    }
}
