using Task_20.Model.Zoo;

namespace Task_20.Model.Save
{
    class ListOfSpeciesWrite
    {
        public ISaveAnimal  Mode {get; set;}

        public ListOfSpeciesWrite(ISaveAnimal SaveAnimal)
        { 
           Mode = SaveAnimal;       
        }

        public void Save(Repository RepositoryAnimal)
        {                       
            Mode.SaveAnimal(RepositoryAnimal);       
        }
    }
}
