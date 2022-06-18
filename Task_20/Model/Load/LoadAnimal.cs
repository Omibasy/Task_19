using System.Collections.Generic;
using System.IO;
using Task_20.Model.Zoo;

namespace Task_20.Model.Load
{
    class LoadAnimal : ILoadAnimal
    {
        private string Data { get; set; }

        public LoadAnimal(string data)
        { 
           this.Data = data;       
        }

        public List<IAnimal> GetAnimalsData()
        {
            List <IAnimal> animals = new List <IAnimal>();

            using (StreamReader sr = new StreamReader(Data))
            {
                string fullText = sr.ReadToEnd();

                string[] rowsText = fullText.Split('#');

                string[] textOfAnimal;

                for (int i = 0; i < rowsText.Length; i++)
                {
                    textOfAnimal = rowsText[i].Split('|');

                    animals.Add(AnimalFactory.GetAnimal(textOfAnimal[0].Trim(),
                                                        textOfAnimal[1].Trim(),
                                                        textOfAnimal[2].Trim(),
                                                        textOfAnimal[3].Trim()));
                }
            }

            return animals;
        }
    }
}
