using Task_20.Model.Zoo;
using System.IO;

namespace Task_20.Model.Save
{
    class KeeperHtml : ISaveAnimal
    {
        private string NameOfFile;

        public KeeperHtml(string NameOfFile)
        {
            this.NameOfFile = NameOfFile;
        }

        public void SaveAnimal(Repository RepositoryAnimal)
        {
            using (StreamWriter sw = new StreamWriter($"{NameOfFile}.html"))
            {
                string[] BaseData = RepositoryAnimal.EnumerationAnimals();

                for (int i = 0; i < BaseData.Length - 1; i++)
                {
                    string line = BaseData[i].Trim();
                    sw.WriteLine($"{line}#");

                }
                sw.WriteLine(BaseData[(BaseData.Length - 1)]);
            }                  
        }
    }
}
