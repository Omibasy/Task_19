using System.Collections.Specialized;
using System.Threading.Tasks;
using Task_20.Model.Zoo;
using Task_20.Model.Save;
using Task_20.Model.Load;
using System.Windows.Input;
using System.ComponentModel;

namespace Task_20.ViewModel
{
    
    class MainWindowViewModel 
    {
        Repository repository;

        string folderAnimals;

        ListOfAnimals<IAnimal> listOfAnimals;

        public string FindAnimal { get; set; }    

        public string[] FileStorage { get; set; }

        public ListOfAnimals<IAnimal> ListOfAnimals 
        {
            get
            { 
                return listOfAnimals;
            }
            set
            {
                listOfAnimals = value;         
            }
        }

        public string AnimalName { get; set; }

        public string ViewAnimals { get; set; }

        public string BreedAnimal { get; set; }

        public string FeaturesAnimal { get; set; }

        public ICommand AddCommand { get; set; }

        public ICommand DeleteCommand { get;  set; }

        public ICommand SaveCommand { get; set; }

        public ICommand LoadCommand { get; set; }

        public MainWindowViewModel() 
        {
            folderAnimals = @"Animals";

            FindFolder();
           
            listOfAnimals = new ListOfAnimals<IAnimal>();

            AddCommand = new Command(Add, (o) => true);
            DeleteCommand = new Command(Delete, (o) => true);
            SaveCommand = new Command(SaveFileAnimals, (o) => true);
            LoadCommand = new Command(LoadFileAnimals, (o) => true);                                      
        }

        private void FindFolder()
        {
            Task.Run(() =>
            {
                FolderContents folderContents = new FolderContents(folderAnimals);

                FileStorage = folderContents.GetFileAnimals();

            }).Wait();
        }

        void SaveFileAnimals(object o)
        {
            if (o == null)
            {
                return;
            }

            string nameFile = (string)o;

            string[] convertDataFile = nameFile.Split('.');

            repository = new Repository(listOfAnimals.ToList());

            ISaveAnimal saveAnimal = FormatDefinition.GetSaveAnimal($"{$@"{folderAnimals}\{convertDataFile[0]}"}", 
                                                                    $"{convertDataFile[1]}");

            ListOfSpeciesWrite listOfSpeciesWrite = new ListOfSpeciesWrite(saveAnimal);

            listOfSpeciesWrite.Save(repository);

            FindFolder();
        }

        void LoadFileAnimals(object o)
        {
            if (o != null)
            {
                Task.Run(() =>
                {
                    listOfAnimals.Clear();
                    repository = RepositoryFactory.GetRepository(new LoadAnimal($"{o}"));

                    listOfAnimals.ToListOfAnimals(repository.GetAnimals());

                }).Wait();

                listOfAnimals.OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                                                      NotifyCollectionChangedAction.Reset));

                for (int i = 0; i < listOfAnimals.Count; i++)
                {
                    listOfAnimals.OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                                                      NotifyCollectionChangedAction.Add, listOfAnimals[i]));
                }
            }
        }

        void Add(object o)
        {
            IAnimal newAnimal = null;

            Task.Run(() =>
            {
                newAnimal = AnimalFactory.GetAnimal(ViewAnimals, BreedAnimal, AnimalName, FeaturesAnimal);

                listOfAnimals.Add(newAnimal);
                ViewAnimals = "";
                BreedAnimal = "";
                AnimalName = "";
                FeaturesAnimal = "";

            }).Wait();

            listOfAnimals.OnCollectionChanged(new NotifyCollectionChangedEventArgs( 
                                            NotifyCollectionChangedAction.Add, newAnimal));           
        }

        void Delete(object o)
        {          
            IAnimal animal = null;
            int index = 0;
    
            Task.Run(() =>
            {
                animal = o as IAnimal;
                index = listOfAnimals.IndexOf(animal);
                listOfAnimals.Remove(animal);

            }).Wait();
            listOfAnimals.OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                                               NotifyCollectionChangedAction.Remove, animal, index));
        }
    }
}

