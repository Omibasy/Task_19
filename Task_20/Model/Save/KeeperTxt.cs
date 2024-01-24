using System.IO;
using Task_20.Model.Zoo;

namespace Task_20.Model.Save
{
    class KeeperTxt : ISaveAnimal
    {
        private string NameOfFile;

        public KeeperTxt(string NameOfFile)
        {
            this.NameOfFile = NameOfFile;
        }

        public void SaveAnimal(Repository RepositoryAnimal)
        {
            string[] data = RepositoryAnimal.EnumerationAnimals();

            if (data.Length == 0)
            {
                return;
            }

            using (StreamWriter sw = new StreamWriter($"{NameOfFile}.txt"))
            {

                for (int i = 0; i < data.Length-1; i++)
                {
                    string line = data[i].Trim();
                    sw.WriteLine($"{line}#");

                }
                sw.WriteLine(data[(data.Length - 1)]);
            }
        }
    }
}
