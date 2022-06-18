using System.Collections.Generic;
using Task_20.Model.Zoo;

namespace Task_20.Model.Load
{
    interface ILoadAnimal
    {
         List<IAnimal> GetAnimalsData();
    }
}
